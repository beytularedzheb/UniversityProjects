package components.pc;

public class VideoCard extends WithMemory {

	private float bandwidth;
	
	public float getBandwidth() {
		return bandwidth;
	}

	public void setBandwidth(float bandwidth) {
		this.bandwidth = bandwidth;
	}
	
	public VideoCard() {
		
	}

	public VideoCard(String name, boolean primary, float memoryCapacity, 
			float bandwidth) {
		super(name, primary, memoryCapacity);
		this.bandwidth = bandwidth;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.bandwidth);
				
		return sb.toString();
	}


}
