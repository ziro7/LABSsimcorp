namespace LABSsimcorp {
    public class TouchKeyboard : Keyboard {
        public bool IsMultiTouch { get; set; }

        public TouchKeyboard(bool supportEmoji, bool isMultiTouch) 
            : base(supportEmoji) {
            IsMultiTouch = isMultiTouch;
        }
    }
}
