
public class Vegetable extends Plant {

	private String usedPart;

	public String getUsedPart() {
		return usedPart;
	}

	public void setUsedPart(String usedPart) {
		this.usedPart = usedPart;
	}
	
	public Vegetable() {
		
	}
	
	public Vegetable(String name, NutrientContent nutrientContent, float net,
			boolean gmo, String origin, String usedPart) {
		super(name, nutrientContent, net, gmo, origin);
		this.usedPart = usedPart;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(usedPart);
		
		return builder.toString();
	}
}
