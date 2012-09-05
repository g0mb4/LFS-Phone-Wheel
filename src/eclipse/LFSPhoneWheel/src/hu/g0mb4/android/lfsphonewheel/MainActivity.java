package hu.g0mb4.android.lfsphonewheel;

import java.util.Timer;

import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.app.Activity;
import android.content.Context;
import android.content.pm.ActivityInfo;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;

import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends Activity implements SensorEventListener {

	private float mLastY = 0;
	private boolean mInitialized;
	private SensorManager mSensorManager;
	private Sensor mAccelerometer;
	private final float NOISE = (float) 2.0;

	private TextView tv;
	private EditText etIP;
	private Button btnConnect, btnGas, btnBrake, btnHandBrake, btnShiftp,
			btnShiftm, btnMouse;

	private TCPClient tcpClient;
	private String serverIP;
	private boolean connected = false;
	
	private Timer t;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		this.requestWindowFeature(Window.FEATURE_NO_TITLE);
		// this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
		// WindowManager.LayoutParams.FLAG_FULLSCREEN); //értesítõsáv
		// kikapcsolása

		setContentView(R.layout.activity_main);
		
		this.setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);

		/* gyorsulásszenzor beállítása */

		mInitialized = false;
		mSensorManager = (SensorManager) getSystemService(Context.SENSOR_SERVICE); //
		mAccelerometer = mSensorManager
				.getDefaultSensor(Sensor.TYPE_ACCELEROMETER); //
		mSensorManager.registerListener(this, mAccelerometer, //
				SensorManager.SENSOR_DELAY_GAME);

		tv = (TextView) findViewById(R.id.textView1);
		etIP = (EditText) findViewById(R.id.etIP);
		btnConnect = (Button) findViewById(R.id.btnConnect);
		btnGas = (Button) findViewById(R.id.btnGas);
		btnBrake = (Button) findViewById(R.id.btnBrake);
		btnHandBrake = (Button) findViewById(R.id.btnHandBrake);
		btnShiftp = (Button) findViewById(R.id.btnShiftp);
		btnShiftm = (Button) findViewById(R.id.btnShiftm);
		btnMouse = (Button) findViewById(R.id.btnMouse);

		btnGas.setEnabled(false);
		btnBrake.setEnabled(false);
		btnHandBrake.setEnabled(false);
		btnShiftp.setEnabled(false);
		btnShiftm.setEnabled(false);
		btnMouse.setEnabled(false);	
		
		btnMouse.setOnClickListener(new View.OnClickListener() {

			public void onClick(View v) {
				try {
					if (tcpClient != null && connected) {
						tcpClient.sendMessage("mouse|");
					}
				} catch (Exception e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

			}
		});

		btnConnect.setOnClickListener(new View.OnClickListener() {

			public void onClick(View v) {
				serverIP = etIP.getText().toString();
				connected = true;
				new connectTask().execute("");

				btnConnect.setEnabled(false);
				etIP.setEnabled(false);
				btnGas.setEnabled(true);
				btnBrake.setEnabled(true);
				btnHandBrake.setEnabled(true);
				btnShiftp.setEnabled(true);
				btnShiftm.setEnabled(true);
				btnMouse.setEnabled(true);
			}
		});

		btnGas.setOnTouchListener(new View.OnTouchListener() {

			public boolean onTouch(View v, MotionEvent event) {
				switch (event.getAction()) {
				case MotionEvent.ACTION_DOWN:
					send("gason|");
					break;
				case MotionEvent.ACTION_UP:
					send("gasoff|");
					break;
				}
				return false;
			}

		});

		btnBrake.setOnTouchListener(new View.OnTouchListener() {

			// private Handler mHandler;

			public boolean onTouch(View v, MotionEvent event) {
				switch (event.getAction()) {
				case MotionEvent.ACTION_DOWN:
					/*
					 * if (mHandler != null) return true; mHandler = new
					 * Handler(); mHandler.postDelayed(mAction, 100);
					 */
					send("brakeon|");
					break;
				case MotionEvent.ACTION_UP:
					/*
					 * if (mHandler == null) return true;
					 * mHandler.removeCallbacks(mAction); mHandler = null;
					 */
					send("brakeoff|");
					break;
				}
				return false;
			}

			/*
			 * Runnable mAction = new Runnable() { public void run() { try { if
			 * (tcpClient != null && connected) {
			 * tcpClient.sendMessage("brake|"); } } catch (Exception e) { //
			 * TODO Auto-generated catch block e.printStackTrace(); }
			 * mHandler.postDelayed(this, 100); } };
			 */
		});

		btnHandBrake.setOnTouchListener(new View.OnTouchListener() {

			public boolean onTouch(View v, MotionEvent event) {
				switch (event.getAction()) {
				case MotionEvent.ACTION_DOWN:
					send("hbrakeon|");
					break;
				case MotionEvent.ACTION_UP:
					send("hbrakeoff|");
					break;
				}
				return false;
			}
		});

		btnShiftp.setOnClickListener(new View.OnClickListener() {

			public void onClick(View v) {
				send("shiftp|");

			}
		});

		btnShiftm.setOnClickListener(new View.OnClickListener() {

			public void onClick(View v) {
				send("shiftm|");
			}
		});

	}

	protected void onPause() {
		super.onPause();
		// mSensorManager.unregisterListener(this);

		System.runFinalizersOnExit(true);
		System.exit(0);
	}

	public void onSensorChanged(SensorEvent event) {

		char ch[] = new char[11];

		float y = event.values[1];

		if (!mInitialized) {
			mLastY = y;
			mInitialized = true;
		} else {
			float deltaY = Math.abs(mLastY - y);

			if (deltaY < NOISE)
				deltaY = (float) 0.0;

			try {
				if (tcpClient != null && connected) {
					tcpClient.sendMessage(Float.toString(y) + "|");
					tv.setText(Float.toString(y));
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
			mLastY = y;

		}
	}

	public void onAccuracyChanged(Sensor arg0, int arg1) {
		// TODO Auto-generated method stub

	}

	public class connectTask extends AsyncTask<String, String, TCPClient> {

		@Override
		protected TCPClient doInBackground(String... message) {

			// we create a TCPClient object and
			tcpClient = new TCPClient(serverIP,
					new TCPClient.OnMessageReceived() {

						// here the messageReceived method is implemented
						public void messageReceived(String message) {
							// this method calls the onProgressUpdate
							publishProgress(message);
						}
					});
			tcpClient.run();
			
			return null;
		}
	}


	private void send(String s) {
		try {
			if (tcpClient != null && connected) {
				tcpClient.sendMessage(s);
			}
			Thread.currentThread().wait(100);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}
