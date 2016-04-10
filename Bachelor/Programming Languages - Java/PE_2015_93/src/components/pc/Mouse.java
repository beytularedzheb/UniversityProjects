package components.pc;

public class Mouse extends InputDevice {

	private float sensitivity;
	
	public float getSensitivity() {
		return sensitivity;
	}

	public void setSensitivity(float sensitivity) {
		this.sensitivity = sensitivity;
	}

	public Mouse() {
		
	}

	public Mouse(String name, boolean wired, String modalityOfInput,
			float sensitivity) {
		super(name, wired, modalityOfInput);
		this.sensitivity = sensitivity;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.sensitivity);
		
		return sb.toString();
	}
	
}
