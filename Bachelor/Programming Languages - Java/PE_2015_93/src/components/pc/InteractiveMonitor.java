package components.pc;

public class InteractiveMonitor extends IODevice {

	private int touchPoints;
	
	public int getTouchPoints() {
		return touchPoints;
	}

	public void setTouchPoints(int touchPoints) {
		this.touchPoints = touchPoints;
	}

	public InteractiveMonitor() {
		
	}

	public InteractiveMonitor(String name, boolean wired, 
			String modalityOfIO, int touchPoints) {
		super(name, wired, modalityOfIO);
		this.touchPoints = touchPoints;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.touchPoints);
				
		return sb.toString();
	}
	
}
