package geofig.shapes;

public class Plane extends Shape {

	private String area;
	
	public Plane() {
		
	}
	
	public Plane(String name, String description, String area) {
		super(name, description);
		this.area = area;
	}

	public Plane(String[] attributes) {
		this(attributes[0], attributes[1], attributes[2]);
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(area);
		
		return builder.toString();
	}

	public String getArea() {
		return area;
	}

	public void setArea(String area) {
		this.area = area;
	}
}
