package geofig.shapes;

public class Ray extends Line {
	
	private float x;
	private float y;
	private String direction; // complex
	
	public Ray() {
		
	}
	
	public Ray(String name, String description, float x, float y, String direction) {
		super(name, description);
		this.x = x;
		this.y = y;
		this.direction = direction;
	}
	
	public Ray(String[] attributes) {
		this(attributes[0], attributes[1], 
				Float.parseFloat(attributes[2]),
				Float.parseFloat(attributes[3]),
				attributes[4]);
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(x).append(", ");
		builder.append(y).append(" | ");
		builder.append(direction);
		
		return builder.toString();
	}

	public float getX() {
		return x;
	}

	public void setX(float x) {
		this.x = x;
	}

	public float getY() {
		return y;
	}

	public void setY(float y) {
		this.y = y;
	}

	public String getDirection() {
		return direction;
	}

	public void setDirection(String direction) {
		this.direction = direction;
	}
	
}
