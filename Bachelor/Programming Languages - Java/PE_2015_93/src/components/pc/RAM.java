package components.pc;

public class RAM extends WithMemory {

	private float frequency;
	
	public float getFrequency() {
		return frequency;
	}

	public void setFrequency(float frequency) {
		this.frequency = frequency;
	}

	public RAM() {
		
	}

	public RAM(String name, boolean primary, float memoryCapacity, 
			float frequency) {
		super(name, primary, memoryCapacity);
		this.frequency = frequency;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.frequency);
				
		return sb.toString();
	}
	
}
