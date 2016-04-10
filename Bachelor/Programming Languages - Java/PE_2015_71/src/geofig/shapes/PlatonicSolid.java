package geofig.shapes;

public class PlatonicSolid extends Polyhedra {

	public PlatonicSolid() {

	}

	public PlatonicSolid(String name, String description, String surfaceArea,
			int vertices) {
		super(name, description, surfaceArea, vertices);
	}
	
	public PlatonicSolid(String[] attributes) {
		super(attributes);
	}
	
	@Override
	public String toString() {
		return super.toString();
	}
	
}
