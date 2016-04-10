package geofig.shapes;

public class IrregularPolygon extends Polygon {

	public IrregularPolygon() {

	}

	public IrregularPolygon(String name, String description, String area,
			int sides) {
		super(name, description, area, sides);

	}

	public IrregularPolygon(String[] attributes) {
		super(attributes);
	}
	
	@Override
	public String toString() {
		return super.toString();
	}
	
}
