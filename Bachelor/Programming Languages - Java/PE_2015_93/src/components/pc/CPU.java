package components.pc;

public class CPU extends WithMemory {

	private int cacheLevels;
	private int numberOfCores;
	private float clockSpeed;
	
	public int getCacheLevels() {
		return cacheLevels;
	}

	public void setCacheLevels(int cacheLevels) {
		this.cacheLevels = cacheLevels;
	}
	
	public int getNumberOfCores() {
		return numberOfCores;
	}

	public void setNumberOfCores(int number) {
		this.numberOfCores = number;
	}

	public float getClockSpeed() {
		return clockSpeed;
	}

	public void setClockSpeed(float clockSpeed) {
		this.clockSpeed = clockSpeed;
	}

	public CPU() {
		
	}

	public CPU(String name, boolean primary, float memoryCapacity, 
			int cacheLevels, int coreNumber, float clockSpeed) {
		super(name, primary, memoryCapacity);
		this.cacheLevels = cacheLevels;
		this.numberOfCores = coreNumber;
		this.clockSpeed = clockSpeed;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.cacheLevels);
		sb.append(", ");
		sb.append(this.numberOfCores);
		sb.append(", ");
		sb.append(this.clockSpeed);
				
		return sb.toString();
	}
	
}
