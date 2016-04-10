package geofig.shapes;

public class RegularPolygon extends Polygon {

	private float interiorAngle;
	
	public RegularPolygon() {
		// TODO Auto-generated constructor stub
	}

	public RegularPolygon(String name, String description, String area,
			int sides, float interiorAngle) {
		super(name, description, area, sides);
		this.interiorAngle = interiorAngle;
	}
	
	public RegularPolygon(String[] attributes) {
		this(attributes[0], attributes[1], attributes[2],
				Integer.parseInt(attributes[3]),
				Float.parseFloat(attributes[4]));
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(interiorAngle);
		
		return builder.toString();
	}

	public float getInteriorAngle() {
		return interiorAngle;
	}

	public void setInteriorAngle(float interiorAngle) {
		this.interiorAngle = interiorAngle;
	}

}
