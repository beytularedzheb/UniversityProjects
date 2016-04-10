package components.pc;

public class Internal extends Component {

	private boolean primary;
	
	public boolean isPrimary() {
		return primary;
	}

	public void setPrimary(boolean primary) {
		this.primary = primary;
	}
	
	public Internal() {
		
	}

	public Internal(String name, boolean primary) {
		super(name);
		this.primary = primary;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");

		if (this.primary) {
			sb.append("Primary");
		}
		else {
			sb.append("Secondary");
		}
		
		return sb.toString();
	}

}
