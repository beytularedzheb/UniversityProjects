package geofig.shapes;

public class Circle extends Curve {

	private float circumference;
	
	public Circle() {

	}

	public Circle(String name, String description, String area,
			float majorAxes, float minorAxes, float circumference) {
		super(name, description, area, majorAxes, minorAxes);
		this.circumference = circumference;
	}
	
	public Circle(String[] attributes) {
		this(attributes[0], attributes[1], attributes[2],
				Float.parseFloat(attributes[3]),
				Float.parseFloat(attributes[4]),
				Float.parseFloat(attributes[5]));
	}

	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(circumference);
		
		return builder.toString();
	}
	
	public float getCircumference() {
		return circumference;
	}

	public void setCircumference(float circumference) {
		this.circumference = circumference;
	}

}
