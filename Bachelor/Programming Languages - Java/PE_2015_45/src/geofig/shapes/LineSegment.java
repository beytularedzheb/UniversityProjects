package geofig.shapes;

public class LineSegment extends Line {

	private float x1;
	private float y1;
	private float x2;
	private float y2;
	
	public LineSegment() {

	}

	public LineSegment(String name, String description, 
			float x1, float y1, float x2, float y2) {
		super(name, description);
		this.x1 = x1;
		this.y1 = y1;
		this.x2 = x2;
		this.y2 = y2;
	}
	
	public LineSegment(String[] attributes) {
		this(attributes[0], attributes[1], 
				Float.parseFloat(attributes[2]),
				Float.parseFloat(attributes[3]),
				Float.parseFloat(attributes[4]),
				Float.parseFloat(attributes[5]));
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(x1).append(", ");
		builder.append(y1).append(" | ");
		builder.append(x2).append(", ");
		builder.append(y2);
		
		return builder.toString();
	}

	public float getX1() {
		return x1;
	}

	public void setX1(float x1) {
		this.x1 = x1;
	}

	public float getY1() {
		return y1;
	}

	public void setY1(float y1) {
		this.y1 = y1;
	}

	public float getX2() {
		return x2;
	}

	public void setX2(float x2) {
		this.x2 = x2;
	}

	public float getY2() {
		return y2;
	}

	public void setY2(float y2) {
		this.y2 = y2;
	}
	
}
