
public class SoftDrink extends Drinkable {

	private boolean carbonated;
	
	public boolean isCarbonated() {
		return carbonated;
	}

	public void setCarbonated(boolean carbonated) {
		this.carbonated = carbonated;
	}
	
	public SoftDrink() {
		
	}
	
	public SoftDrink(String name, NutrientContent nutrientContent, float net,
			boolean natural, boolean carbonated) {
		super(name, nutrientContent, net, natural);
		this.carbonated = carbonated;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(carbonated);
		
		return builder.toString();
	}
}
