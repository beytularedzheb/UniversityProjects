package geofig.shapes;

public class Polygon extends Plane {

	private int sides;
	
	public Polygon() {
		// TODO Auto-generated constructor stub
	}

	public Polygon(String name, String description, String area, int sides) {
		super(name, description, area);
		this.sides = sides;
	}
	
	public Polygon(String[] attributes) {
		this(attributes[0], attributes[1], 
				attributes[2], Integer.parseInt(attributes[3]));
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(sides);
		
		return builder.toString();
	}
	
	public int getSides() {
		return sides;
	}

	public void setSides(int sides) {
		this.sides = sides;
	}

}
