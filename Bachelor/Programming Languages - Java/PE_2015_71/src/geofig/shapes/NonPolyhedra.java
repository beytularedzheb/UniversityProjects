package geofig.shapes;

public class NonPolyhedra extends Solid {

	public NonPolyhedra() {

	}

	public NonPolyhedra(String name, String description, String surfaceArea) {
		super(name, description, surfaceArea);
	}
	
	public NonPolyhedra(String[] attributes) {
		super(attributes);
	}

	@Override
	public String toString() {
		return super.toString();
	}
	
}
