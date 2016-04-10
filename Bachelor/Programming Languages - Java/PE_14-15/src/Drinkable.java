
public class Drinkable extends Foodstuff {
	
	private boolean natural;

	public boolean isNatural() {
		return natural;
	}

	public void setNatural(boolean natural) {
		this.natural = natural;
	}
	
	public Drinkable() {
		
	}
	
	public Drinkable(String name, NutrientContent nutrientContent, 
			float net, boolean natural) {
		super(name, nutrientContent, net);
		this.natural = natural;
	}

	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(natural);
		
		return builder.toString();
	}
}
