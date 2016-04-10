package components.pc;

public class Microphone extends InputDevice {

	private String pickUpPattern; /* omni, bi-directional, cardioid,
									hyper-cardioid, shotgun */
	
	public String getPickUpPattern() {
		return pickUpPattern;
	}

	public void setPickUpPattern(String pickUpPattern) {
		this.pickUpPattern = pickUpPattern;
	}

	public Microphone() {
		
	}

	public Microphone(String name, boolean wired, String modalityOfInput, 
			String pickUpPattern) {
		super(name, wired, modalityOfInput);
		this.pickUpPattern = pickUpPattern;
	}
	
	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");		
		sb.append(this.pickUpPattern);
				
		return sb.toString();
	}

}
