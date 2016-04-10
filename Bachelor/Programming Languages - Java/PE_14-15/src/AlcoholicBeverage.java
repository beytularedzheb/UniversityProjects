
//този клас наследява класа Drinkable
public class AlcoholicBeverage extends Drinkable {

	//има собствено поле alcoholByVolume - процентът на алкохол
	//т.к е private извън този клас няма да имаме дитектен достъп до това поле
	//но можем да го достъпваме чрез getter'и и setter'и  - getAlcoholByVolume() и setAlcoholByVolume()
	private float alcoholByVolume;

	public float getAlcoholByVolume() {
		return alcoholByVolume;
	}

	public void setAlcoholByVolume(float alcoholByVolume) {
		this.alcoholByVolume = alcoholByVolume;
	}
	
	//конструкторът по подразбиране
	public AlcoholicBeverage() {

	}
	
	//инициализиращ конструктор - задължителен
	public AlcoholicBeverage(String name, NutrientContent nutrientContent,
			float net, boolean natural, float alcoholByVolume) {
		//извикваме конструктора на родителя - Drinkable
		super(name, nutrientContent, net, natural);
		this.alcoholByVolume = alcoholByVolume;
	}
	
	//пренаписваме (override'ваме) функцията toString() - всички обекти в java го имат
	//може да се ползва и друга наша функция, но предпочетох да го направя по този начин.
	//връща String със стойностите на атрибутите на даден обект, разделени с | - за да ме разбереш
	//по-добре стартирай приложението и виж текста в текстовото поле, обърни внимание на -> |
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(alcoholByVolume);
		
		return builder.toString();
	}
}
