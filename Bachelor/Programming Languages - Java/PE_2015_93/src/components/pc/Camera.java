package components.pc;

public class Camera extends InputDevice {

	private float resolution;
	
	public float getResolution() {
		return resolution;
	}

	public void setResolution(float resolution) {
		this.resolution = resolution;
	}

	public Camera() {
		
	}

	public Camera(String name, boolean wired, String modalityOfInput, 
			float resolution) {
		super(name, wired, modalityOfInput);
		this.resolution = resolution;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.resolution);
				
		return sb.toString();
	}
	
}
