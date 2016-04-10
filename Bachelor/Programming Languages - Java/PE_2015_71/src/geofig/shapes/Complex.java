package geofig.shapes;

public class Complex extends Polygon {

	public Complex() {

	}

	public Complex(String name, String description, String area, 
			int sides) {
		super(name, description, area, sides);
	}
	
	public Complex(String[] attributes) {
		super(attributes);
	}
	
	@Override
	public String toString() {
		return super.toString();
	}
}
