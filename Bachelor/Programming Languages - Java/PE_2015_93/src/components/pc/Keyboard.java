package components.pc;

public class Keyboard extends InputDevice {

	private String countryLayout;
	private boolean integratedTrackball;
	
	public String getCountryLayout() {
		return countryLayout;
	}

	public void setCountryLayout(String countryLayout) {
		this.countryLayout = countryLayout;
	}

	public boolean hasIntegratedTrackball() {
		return integratedTrackball;
	}

	public void setIntegratedTrackball(boolean integratedTrackball) {
		this.integratedTrackball = integratedTrackball;
	}
	
	public Keyboard() {
		
	}

	public Keyboard(String name, boolean wired, String modalityOfInput, 
			String countryLayout, boolean integratedTrackball) {
		super(name, wired, modalityOfInput);
		this.countryLayout = countryLayout;
		this.integratedTrackball = integratedTrackball;
	}

	
	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");		
		sb.append(this.countryLayout);
		sb.append(", ");
		if (this.integratedTrackball) {
			sb.append("Has integrated trackball");
		}
		else {
			sb.append("Doesn't have integrated trackball");
		}
		
		return sb.toString();
	}
}
