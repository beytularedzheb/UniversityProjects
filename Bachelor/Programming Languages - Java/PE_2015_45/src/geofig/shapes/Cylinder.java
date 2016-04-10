package geofig.shapes;

public class Cylinder extends NonPolyhedra {

	public Cylinder() {
		
	}

	public Cylinder(String name, String description, String surfaceArea) {
		super(name, description, surfaceArea);
	}
	
	public Cylinder(String[] attributes) {
		super(attributes);
	}

	@Override
	public String toString() {
		return super.toString();
	}
	
}
