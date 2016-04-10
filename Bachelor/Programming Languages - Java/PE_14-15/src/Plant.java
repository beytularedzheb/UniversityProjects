
public class Plant extends Eateable {

	private String origin;

	public String getOrigin() {
		return origin;
	}

	public void setOrigin(String origin) {
		this.origin = origin;
	}
	
	public Plant() {
		
	}
	
	public Plant(String name, NutrientContent nutrientContent, float net,
			boolean gmo, String origin) {
		super(name, nutrientContent, net, gmo);
		this.origin = origin;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(origin);
		
		return builder.toString();
	}
}
