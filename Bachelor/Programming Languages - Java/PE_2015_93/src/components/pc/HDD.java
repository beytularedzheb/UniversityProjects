package components.pc;

public class HDD extends WithMemory {

	private float latency;
	
	public float getLatency() {
		return latency;
	}

	public void setLatency(float latency) {
		this.latency = latency;
	}

	public HDD() {
		
	}

	public HDD(String name, boolean primary, float memoryCapacity, 
			float speed) {
		super(name, primary, memoryCapacity);
		this.latency = speed;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.latency);
				
		return sb.toString();
	}

}
