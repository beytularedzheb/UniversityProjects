package components.pc;

public class Speacker extends OutputDevice {

	private float power;
	
	public float getPower() {
		return power;
	}

	public void setPower(float power) {
		this.power = power;
	}

	
	public Speacker() {
		
	}

	public Speacker(String name, boolean wired, String modalityOfOuput, 
			float power) {
		super(name, wired, modalityOfOuput);
		this.power = power;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.power);
				
		return sb.toString();
	}
	
}
