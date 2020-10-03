using System.Threading;
using WindowsInput;
using SharpDX.XInput;
using System.Windows.Forms;

namespace XBoxAsMouse
{
	public class XBoxControllerAsMouse
	{
		private const int MovementDivider = 2_000;
		private const int ScrollDivider = 10_000;
		private const int RefreshRate = 60;

		private System.Threading.Timer _timer;
		private Controller _controller;
		private IMouseSimulator _mouseSimulator;
        private IKeyboardSimulator _keyboardSimulator;
        
        
        // A, B, X, Y
		private bool _wasADown;
		private bool _wasBDown;
        private bool _wasXDown;
        private bool _wasYDown;
        // arrow keys
        private bool _wasUpArrowDown;
        private bool _wasDownArrowDown;
        private bool _wasLeftArrowDown;
        private bool _wasRightArrowDown;
        // start, menu
        private bool _wasMenuDown;
        private bool _wasStartDown;
        // thumb pads
        private bool _wasLeftThumbDown;
        private bool _wasRightThumbDown;
        // bumpers and triggers
        private bool _wasLeftBumperDown;
        private bool _wasLeftTriggerDown;
        private bool _wasRightBumperDown;
        private bool _wasRightTriggerDown;

        public XBoxControllerAsMouse()
		{
			_controller = new Controller(UserIndex.One);
			_mouseSimulator = new InputSimulator().Mouse;
            _keyboardSimulator = new InputSimulator().Keyboard;
			_timer = new System.Threading.Timer(obj => Update());
		}

		public void Start()
		{
			_timer.Change(0, 1000 / RefreshRate);
		}

		private void Update()
		{
			_controller.GetState(out var state);
			Movement(state);
			Scroll(state);
            // A, B, X, Y
			A_Button(state);
			B_Button(state);
            X_Button(state);
            Y_Button(state);
            // Arrow Keys
            Up_Button(state);
            Down_Button(state);
            Left_Button(state);
            Right_Button(state);
            // Start, Menu
            Start_Button(state);
            Menu_Button(state);
            // Thumb Pads
            LeftThumb_Button(state);
            RightThumb_Button(state);
            // Bumpers, Triggers
            LeftBumper_Button(state);
            RightBumper_Button(state);
            LeftTrigger_Button(state);
            RightTrigger_Button(state);

		}

        // A, B, X, Y
		private void A_Button(State state) // Accept And Move Forward (only for Car ID)
		{
			var isADown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
            try
            {
                if (isADown && !_wasADown) SendKeys.SendWait("{ENTER}");
                if (isADown && !_wasADown) SendKeys.SendWait("{ENTER}");
                if (isADown && !_wasADown) SendKeys.SendWait("{RIGHT}");
                if (isADown && !_wasADown) SendKeys.SendWait("i");
            }
            catch (System.Exception e)
            {
                // do something
            }
            _wasADown = isADown;
		}

        private void B_Button(State state) // Delete Selection Box
		{
			var isBDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
            try
            {
                if (isBDown && !_wasBDown) SendKeys.SendWait("d");
            }
            catch (System.Exception e)
            {
                // do something
            }
            _wasBDown = isBDown;
		}

        private void X_Button(State state) // Accept Current Selection
        {
            var isXDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
            try
            {
                if (isXDown && !_wasXDown) SendKeys.SendWait("{ENTER}");
            } catch (System.Exception e) {
                // do something
            }
            _wasXDown = isXDown;
        }

        private void Y_Button(State state) // Move Back One Image
        {
            var isYDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
            try
            {
                if (isYDown && !_wasYDown) SendKeys.SendWait("s");
                if (isYDown && !_wasYDown) SendKeys.SendWait("{LEFT}");
                if (isYDown && !_wasYDown) SendKeys.SendWait("i");
            }
            catch (System.Exception e)
            {
                // do something
            }
            _wasYDown = isYDown;
        }

        // Arrow Keys
        private void Up_Button(State state) // Expand Box Up
        {
            if (state.Gamepad.LeftTrigger < 5)
            {
                var isUpArrowDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
                if (isUpArrowDown && !_wasUpArrowDown)
                    try
                {
                    SendKeys.SendWait("{UP}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
            }
        }

        private void Down_Button(State state) // Expand Box Down
        {
            if (state.Gamepad.LeftTrigger < 5)
            {
                var isDownArrowDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
                if (isDownArrowDown && !_wasDownArrowDown)
                    try
                {
                    SendKeys.SendWait("{DOWN}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
            }
        }

        private void Left_Button(State state) // Expand Box To The Left
        {

            if (state.Gamepad.LeftTrigger < 5)
            {
                var isLeftArrowDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
                if (isLeftArrowDown && !_wasLeftArrowDown)
                    try {
                    SendKeys.SendWait("{LEFT}");
                } catch (System.Exception e)
                {
                    // do something
                }
            }
        }

        private void Right_Button(State state) // Expand Box To The Right
        {

            if (state.Gamepad.LeftTrigger < 5)
            {
                var isRightArrowDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
                if (isRightArrowDown && !_wasRightArrowDown)
                    try
                {
                    SendKeys.SendWait("{RIGHT}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
            }
        }

        // Start, Menu
        private void Start_Button(State state) // Inspect Properties
        {
            var isStartDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start);
            try
            {
                if (isStartDown && !_wasStartDown) SendKeys.SendWait("s");
            }
            catch (System.Exception e)
            {
                // do something
            }
            _wasStartDown = isStartDown;
        }

        private void Menu_Button(State state) // Quite Menu 
        {
            var isMenuDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back); // <--- menu button
            try
            {
                if (isMenuDown && !_wasMenuDown) SendKeys.SendWait("{ESC}");
            }
            catch (System.Exception e)
            {
                // do something
            }
            _wasMenuDown = isMenuDown;
        }

        // Thumb Pads
        private void LeftThumb_Button(State state) // Unmapped
        {
            var isLeftThumbDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb);
            try
            {
                if (isLeftThumbDown && !_wasLeftThumbDown) SendKeys.SendWait("l");
                if (!isLeftThumbDown && _wasLeftThumbDown) SendKeys.SendWait("u");
            }
            catch (System.Exception e)
            {
                // do something
            }
            _wasLeftThumbDown = isLeftThumbDown;
        }

        private void RightThumb_Button(State state) // Create New Box
        {
            var isRightThumbDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);
            try
            {
                if (isRightThumbDown && !_wasRightThumbDown) SendKeys.SendWait("r");
            }
            catch (System.Exception e)
            {
                // do something
            }
            _wasRightThumbDown = isRightThumbDown;
        }

        // Bumpers
        private void RightBumper_Button(State state)  // Right Mouse Click
        {
            var isRightBumperDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);
            if (isRightBumperDown && !_wasRightBumperDown) _mouseSimulator.LeftButtonDown();
            if (!isRightBumperDown && _wasRightBumperDown) _mouseSimulator.LeftButtonUp();
            _wasRightBumperDown = isRightBumperDown;
        }

        private void LeftBumper_Button(State state) // Left Mouse Click
        {
            var isLeftBumperDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
            if (isLeftBumperDown && !_wasLeftBumperDown) _mouseSimulator.RightButtonDown();
            if (!isLeftBumperDown && _wasLeftBumperDown) _mouseSimulator.RightButtonUp();
            _wasLeftBumperDown = isLeftBumperDown;
        }

        // Triggers Actions
        private void LeftTrigger_Button(State state) // Move Box
        {
            var z = state.Gamepad.LeftTrigger;
            if (z > 4)
            {
                // set up the arrow keys
                var isUpArrowDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
                var isDownArrowDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
                var isLeftArrowDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
                var isRightArrowDown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);

                // send the "Shift" + "Arrow Key"
                if (isUpArrowDown && !_wasUpArrowDown)
                    try
                {
                    SendKeys.SendWait("+{UP}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
                if (isUpArrowDown && !_wasUpArrowDown)
                    try
                {
                    SendKeys.SendWait("+{UP}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
                //_wasUpArrowDown = isUpArrowDown; // disabled to spam this key
                if (isDownArrowDown && !_wasDownArrowDown)
                    try
                {
                    SendKeys.SendWait("+{DOWN}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
                if (isDownArrowDown && !_wasDownArrowDown)
                    try
                {
                    SendKeys.SendWait("+{DOWN}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
                //_wasDownArrowDown = isDownArrowDown; // disabled to spam this key
                if (isLeftArrowDown && !_wasLeftArrowDown)
                    try
                {
                    SendKeys.SendWait("+{LEFT}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
                if (isLeftArrowDown && !_wasLeftArrowDown)
                    try
                {
                    SendKeys.SendWait("+{LEFT}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
                //_wasLeftArrowDown = isLeftArrowDown; // disabled to spam this key
                if (isRightArrowDown && !_wasRightArrowDown)
                    try
                {
                    SendKeys.SendWait("+{RIGHT}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
                if (isRightArrowDown && !_wasRightArrowDown)
                    try
                {
                    SendKeys.SendWait("+{RIGHT}");
                }
                catch (System.Exception e)
                {
                    // do something
                }
                //_wasRightArrowDown = isRightArrowDown; // disabled to spam this key
            }

        }

        private void RightTrigger_Button(State state) // Decrease Box Size (equally in all directions)
        {
            //var z1 = state.Gamepad.LeftTrigger;
            var z2 = state.Gamepad.RightTrigger;
            if (z2 > 4 )//&& z1 < 4)
            {
                try
                {
                    SendKeys.SendWait("-");
                }
                catch (System.Exception e)
                {
                    // do something
                }
            }
        }


        // Thumb Pad Actions
        private void Scroll(State state)
		{
			var x = state.Gamepad.RightThumbX / ScrollDivider;
			var y = state.Gamepad.RightThumbY / ScrollDivider;
			_mouseSimulator.HorizontalScroll(x);
			_mouseSimulator.VerticalScroll(y);
		}

		private void Movement(State state)
		{
            var stickyFactor = 2;
            var sensativity = 200;
            var x = state.Gamepad.LeftThumbX / MovementDivider;
            var y = state.Gamepad.LeftThumbY / MovementDivider;
            if (x < stickyFactor && x > -stickyFactor)
                x = 0;
            if (y < stickyFactor && y > -stickyFactor)
                y = 0;
            _mouseSimulator.MoveMouseBy(x, -y);
		}
	}
}