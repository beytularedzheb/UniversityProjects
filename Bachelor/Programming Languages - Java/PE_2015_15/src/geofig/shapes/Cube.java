package geofig.shapes;

public class Cube extends Polyhedra {

	public Cube() {

	}

	public Cube(String name, String description, String surfaceArea,
			int vertices) {
		super(name, description, surfaceArea, vertices);
	}
	
	public Cube(String[] attributes) {
		super(attributes);
	}
	
	@Override
	public String toString() {
		return super.toString();
	}
	
}
