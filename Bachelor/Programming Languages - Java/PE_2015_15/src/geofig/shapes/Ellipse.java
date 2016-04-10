package geofig.shapes;

public class Ellipse extends Curve {

	private String specialCase;
	
	public Ellipse() {

	}

	public Ellipse(String name, String description, String area,
			float majorAxes, float minorAxes) {
		super(name, description, area, majorAxes, minorAxes);
	}
	
	public Ellipse(String[] attributes) {
		super(attributes);
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(this.getSpecialCase());
		
		return builder.toString();
	}

	public String getSpecialCase() {
		if (this.getMajorAxes() == this.getMinorAxes()) {
			specialCase = "Circle: major axes = minor axes.";
		}
		else {
			specialCase = "Ellipse: major axes != minor axes.";
		}
		
		return specialCase;
	}

	public void setSpecialCase(String specialCase) {
		this.specialCase = specialCase;
	}
}
