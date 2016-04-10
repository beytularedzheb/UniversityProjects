package components.pc;

public class WithMemory extends Internal {

	private float memoryCapacity;
	
	public float getMemoryCapacity() {
		return memoryCapacity;
	}

	public void setMemoryCapacity(float memoryCapacity) {
		this.memoryCapacity = memoryCapacity;
	}
	
	public WithMemory() {
		
	}

	public WithMemory(String name, boolean primary, float memoryCapacity) {
		super(name, primary);
		this.memoryCapacity = memoryCapacity;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.memoryCapacity);
				
		return sb.toString();
	}

}
