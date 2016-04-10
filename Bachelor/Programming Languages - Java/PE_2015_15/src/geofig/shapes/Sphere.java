package geofig.shapes;

public class Sphere extends NonPolyhedra {

	public Sphere() {

	}

	public Sphere(String name, String description, String surfaceArea) {
		super(name, description, surfaceArea);
	}
	
	public Sphere(String[] attributes) {
		super(attributes);
	}
	
	@Override
	public String toString() {
		return super.toString();
	}
	
}
