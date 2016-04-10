package components.pc;

public class MotherBoard extends WithoutMemory {

	private String cpuSocket;
	
	public String getCpuSocket() {
		return cpuSocket;
	}

	public void setCpuSocket(String cpuSocket) {
		this.cpuSocket = cpuSocket;
	}

	public MotherBoard() {
		
	}

	public MotherBoard(String name, boolean primary, String cpuSocket) {
		super(name, primary);
		this.cpuSocket = cpuSocket;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.cpuSocket);
				
		return sb.toString();
	}

}
