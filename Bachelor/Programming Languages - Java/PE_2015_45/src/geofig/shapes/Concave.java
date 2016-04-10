package geofig.shapes;

public class Concave extends Polygon {

	public Concave() {

	}

	public Concave(String name, String description, String area, 
			int sides) {
		super(name, description, area, sides);
	}
	
	public Concave(String[] attributes) {
		super(attributes);
	}
	
	@Override
	public String toString() {
		return super.toString();
	}
}
