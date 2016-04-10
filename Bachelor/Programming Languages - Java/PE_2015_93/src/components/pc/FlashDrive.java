package components.pc;

public class FlashDrive extends IODevice {

	private float capacity;
	
	public float getCapacity() {
		return capacity;
	}

	public void setCapacity(float capacity) {
		this.capacity = capacity;
	}

	public FlashDrive() {
		
	}

	public FlashDrive(String name, boolean wired, 
			String modalityOfIO, float capacity) {
		super(name, wired, modalityOfIO);
		this.capacity = capacity;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.capacity);
				
		return sb.toString();
	}
	
}
