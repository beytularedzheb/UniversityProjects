package components.pc;

public class External extends Component {

	private boolean wired;
	
	public boolean isWired() {
		return wired;
	}

	public void setWired(boolean wired) {
		this.wired = wired;
	}
	
	public External() {
		
	}

	public External(String name, boolean wired) {
		super(name);
		this.wired = wired;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");		
		if (this.wired) {
			sb.append("Wired");
		}
		else {
			sb.append("Wireless");
		}
				
		return sb.toString();
	}
}
