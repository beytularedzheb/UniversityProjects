
public class Fermented extends AlcoholicBeverage {

	private String product;

	public String getProduct() {
		return product;
	}

	public void setProduct(String product) {
		this.product = product;
	}
	
	public Fermented() {
		
	}
	
	public Fermented(String name, NutrientContent nutrientContent, float net,
			boolean natural, float alcoholByVolume, String product) {
		super(name, nutrientContent, net, natural, alcoholByVolume);
		this.product = product;
	}

	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(product);
		
		return builder.toString();
	}
}
