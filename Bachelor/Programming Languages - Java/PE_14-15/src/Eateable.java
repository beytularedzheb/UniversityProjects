
public class Eateable extends Foodstuff {

	private boolean gmo;
	
	public boolean isGmo() {
		return gmo;
	}

	public void setGmo(boolean gmo) {
		this.gmo = gmo;
	}

	public Eateable() {
		
	}
	
	public Eateable(String name, NutrientContent nutrientContent, 
			float net, boolean gmo) {
		super(name, nutrientContent, net);
		this.gmo = gmo;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(gmo);
		
		return builder.toString();
	}
}
