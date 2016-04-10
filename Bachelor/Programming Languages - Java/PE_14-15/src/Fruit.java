
public class Fruit extends Plant {

	private boolean dried;

	public boolean isDried() {
		return dried;
	}

	public void setDried(boolean dried) {
		this.dried = dried;
	}
	
	public Fruit() {
		
	}
	
	public Fruit(String name, NutrientContent nutrientContent, float net,
			boolean gmo, String origin, boolean dried) {
		super(name, nutrientContent, net, gmo, origin);
		this.dried = dried;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(dried);
		
		return builder.toString();
	}
}
