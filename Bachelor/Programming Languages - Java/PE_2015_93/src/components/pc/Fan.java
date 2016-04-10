package components.pc;

public class Fan extends WithoutMemory {

	private float rotationalSpeed;
	
	public float getRotationalSpeed() {
		return rotationalSpeed;
	}

	public void setRotationalSpeed(float rotationalSpeed) {
		this.rotationalSpeed = rotationalSpeed;
	}

	public Fan() {
		
	}

	public Fan(String name, boolean primary, float rotationalSpeed) {
		super(name, primary);
		this.rotationalSpeed = rotationalSpeed;
	}
	
	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.rotationalSpeed);
				
		return sb.toString();
	}

}
