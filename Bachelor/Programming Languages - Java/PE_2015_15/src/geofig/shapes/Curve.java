package geofig.shapes;

public class Curve extends Plane {

	private float majorAxes;
	private float minorAxes;
	
	public Curve() {

	}

	public Curve(String name, String description, String area, 
			float majorAxes, float minorAxes) {
		super(name, description, area);
		this.majorAxes = majorAxes;
		this.minorAxes = minorAxes;
	}

	public Curve(String[] attributes) {
		this(attributes[0], attributes[1], 
				attributes[2], 
				Float.parseFloat(attributes[3]),
				Float.parseFloat(attributes[4]));
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(majorAxes).append(" | ");
		builder.append(minorAxes);
		
		return builder.toString();
	}
	
	public float getMajorAxes() {
		return majorAxes;
	}

	public void setMajorAxes(float majorAxes) {
		this.majorAxes = majorAxes;
	}

	public float getMinorAxes() {
		return minorAxes;
	}

	public void setMinorAxes(float minorAxes) {
		this.minorAxes = minorAxes;
	}

}
