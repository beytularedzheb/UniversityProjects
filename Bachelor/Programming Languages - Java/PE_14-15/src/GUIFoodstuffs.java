import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FilenameFilter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;


public class GUIFoodstuffs implements ActionListener {
	
	//всеки атрибут, записан в текстов файл се разделя
	//от другите с този знак ":" - отвори някой файл
	// например Dairy.txt, за да ти е по-ясно
	private final String SPLITTER = ":";
	
	//масив от файлове - съдържа всички файлове от избраната
	//директория - Dairy.txt, Distilled.txt и т.н.
	private File[] files;
	//текстовото поле, в което се извеждат данните
	private JTextArea taContent;
	//бутонът за отваряне на диалога за избор на папка
	private JButton btnFile;
	//бутонът, с който се извеждат данните в текстовото поле
	private JButton btnShow;
	//диалогът за избор на папката с файловете
	private JFileChooser fc;
	//прозорецът на приложението
	private JFrame frame;
	
	//списъкът, в който се записват всички обекти,
	//прочетени от текстовите файлове
	private ArrayList<Foodstuff> fsList;
	//съхранява броя на атрибутите на класа Foodstuff
	private int numberOfAttr;
	
	//конструкторът на класа
	public GUIFoodstuffs(String title) {
		//създаване на списъка
		fsList = new ArrayList<>();
		//включване на декорациите на JavaCodebaseComponent
		//ако изтриеш този ред или подадеш false приложението
		//ще изглежда като windows app - рамката, бутоните за минизиране, изход и т.н.
		JFrame.setDefaultLookAndFeelDecorated(true);
		//създаване на прозореца
		frame = new JFrame(title);
		//когато натиснеш X в десния-горен ъгъл приложението спира
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//задаване типа на Layout'a на прозореца, по какъв начин
		//елементите в прозореца да се организират(подреждат)
		frame.getContentPane().setLayout(new BorderLayout());
		
		//създаване на диалога за избор на папката с файловете
		fc = new JFileChooser();
		fc.setCurrentDirectory(new java.io.File("."));
	    fc.setDialogTitle("Изберете директория");
		//по прицип с този диалог се избират файлове, а не папки, но
		//може да се направи така че да се избира само папка - DIRECTORIES_ONLY
	    fc.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
		//след като отвориш диалога има поле, от което избираш типа
		//на файла, по подразбиране имаш All Files - долният ред го маха
	    fc.setAcceptAllFileFilterUsed(false);
		
		
		/***********************************************************************/
		//създаване на панела, в който ще са разположени двата бутона
		//GridLayout(0, 2) - "0" реда и 2 колони
		JPanel pnlButtons = new JPanel(new GridLayout(0, 2));
		
		//създаване на бутона за отваряне на диалога
		btnFile = new JButton("Въвеждане на данни от файл");
		//добавяне на слушател - функция, която ти дава възможност
		//да разбереш кога бутонът е натиснат и следователно да направиш
		//нещо - в случая отваряме диалога
		btnFile.addActionListener(this);
		//добавяне на бутона в панела
		pnlButtons.add(btnFile);
        
        btnShow = new JButton("Покажи");
        btnShow.addActionListener(this);
		//първоначално този бутон е деактивиран,т.е.
		//не може да се избира (кликва)
        btnShow.setEnabled(false);
        pnlButtons.add(btnShow);
        
		//добавяне на панела в прозореца
        frame.getContentPane().add(pnlButtons, BorderLayout.PAGE_START);
        /***********************************************************************/
        
        
        /***********************************************************************/
        //създаване на панела, в която ще има текстово поле
		JPanel pnlContent = new JPanel(new BorderLayout());
        
		//създаване на текстовото поле
        taContent = new JTextArea();
        
		//създаване на поле с възможност за скролиране и в този панел
		//добавяме текстовото поле, защото последното не разполага 
		//с такава възможност
        JScrollPane scroll = new JScrollPane (taContent, 
        	JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
        
		//добавяне на скрол панела в основния панел
        pnlContent.add(scroll, BorderLayout.CENTER);
        
		//добавяне на панел в прозореца
        frame.getContentPane().add(pnlContent, BorderLayout.CENTER);
        /***********************************************************************/
        
        //не съм сигурен точно какво прави, но ако setSize е
		//преди него прозорецът остава с някакви други размери
		frame.pack();
		//задаване размера на прозореца
		frame.setSize(500, 500);
		//прозорецът да не може да се оразмерява
		frame.setResizable(false);
		//да се появява в центъра на екрана
		frame.setLocationRelativeTo(null);
		//прозоревът по подразбиране е невидим, долният ред го прави видим
        frame.setVisible(true);
	}
	
	private void readFiles() {
		//нулиране на списъка с обектит
		fsList.clear();
		
		//вземане броя на атрибутете на класа Foodstuff. -1 защото
		//NutrientContent е също клас с 5 атрибута
		numberOfAttr = Foodstuff.class.getDeclaredFields().length - 1; // minus 1 NutrientContent
		numberOfAttr += NutrientContent.class.getDeclaredFields().length;
		
		//прочитаме съдържанието на избраните файлове, 1 по 1
		for (File file : files) {
			//т.к всички класове съдържат атрибутите на Foodstuff с цел съкращаване на кода
			//прочитането на първите numberOfAttr атрибута се прави тук
			//този списък съдържа толкова на брой елемнта, колкото са обектите в текущия файл
			//например в Distilled.txt има 2 обекта (2 реда)
			ArrayList<String[]> objectsAttr = getAttributes(file);
			//цикъл, с който се обхожда горният списък
			for (String[] item : objectsAttr) {
					//записване на първите numberOfAttr атрибута в обект
					Foodstuff foodstuff = 
							getObject(Arrays.copyOfRange(item, 0, numberOfAttr));
					
					//отделяме името на файла от разширението му - Distilled.txt -> distilled
					//задължително имената файловете трябва да отговарят на имената на класовете (в случая) или
					//каквото пише в FoodstuffClasses.java - виж го!
					String fileName = file.getName().substring(0, file.getName().
							length() - ".txt".length()).toLowerCase();
					
					//проверяваме какъв обект имаме: ако fileName e distilled, то
					// ще се изпълние "case FoodstuffClasses.DISTILLED"
					switch (fileName) {
						case FoodstuffClasses.ALCOHOLICBEVERAGE:
							AlcoholicBeverage ab = new AlcoholicBeverage();
							ab.setName(foodstuff.getName());
							ab.setNutrientContent(foodstuff.getNutrientContent());
							ab.setNet(foodstuff.getNet());
							ab.setNatural(Boolean.parseBoolean(item[numberOfAttr]));
							ab.setAlcoholByVolume(Float.parseFloat(item[numberOfAttr+1]));
							fsList.add(ab);
						break;
						case FoodstuffClasses.ANIMAL:
							Animal animal = new Animal();
							animal.setName(foodstuff.getName());
							animal.setNutrientContent(foodstuff.getNutrientContent());
							animal.setNet(foodstuff.getNet());
							animal.setGmo(Boolean.parseBoolean(item[numberOfAttr]));
							animal.setTypeOfAnimal(item[numberOfAttr+1]);
							fsList.add(animal);
						break;
						case FoodstuffClasses.DAIRY:
							Dairy dairy = new Dairy();
							dairy.setName(foodstuff.getName());
							dairy.setNutrientContent(foodstuff.getNutrientContent());
							dairy.setNet(foodstuff.getNet());
							dairy.setGmo(Boolean.parseBoolean(item[numberOfAttr]));
							dairy.setTypeOfAnimal(item[numberOfAttr+1]);
							dairy.setPasteurized(Boolean.parseBoolean(item[3]));
							fsList.add(dairy);
						break;
						case FoodstuffClasses.DISTILLED:
							//създаваме обект от тип Distilled
							Distilled distilled = new Distilled();
							//задаваме стойностите на атрибутите му
							distilled.setName(foodstuff.getName());
							distilled.setNutrientContent(foodstuff.getNutrientContent());
							distilled.setNet(foodstuff.getNet());
							distilled.setNatural(Boolean.parseBoolean(item[numberOfAttr]));
							distilled.setAlcoholByVolume(Float.parseFloat(item[numberOfAttr+1]));
							distilled.setAroma(item[numberOfAttr+2]);
							//добавяме distilled в списъка
							fsList.add(distilled);
						break;
						
						case FoodstuffClasses.DRINKABLE:
							Drinkable drinkable = new Drinkable();
							drinkable.setName(foodstuff.getName());
							drinkable.setNutrientContent(foodstuff.getNutrientContent());
							drinkable.setNet(foodstuff.getNet());
							drinkable.setNatural(Boolean.parseBoolean(item[numberOfAttr]));
							fsList.add(drinkable);
						break;
						case FoodstuffClasses.EATEABLE:
							Eateable eatable = new Eateable();
							eatable.setName(foodstuff.getName());
							eatable.setNutrientContent(foodstuff.getNutrientContent());
							eatable.setNet(foodstuff.getNet());
							eatable.setGmo(Boolean.parseBoolean(item[numberOfAttr]));
							fsList.add(eatable);
						break;
		
						case FoodstuffClasses.EGG:
							Egg egg = new Egg();
							egg.setName(foodstuff.getName());
							egg.setNutrientContent(foodstuff.getNutrientContent());
							egg.setNet(foodstuff.getNet());
							egg.setGmo(Boolean.parseBoolean(item[numberOfAttr]));
							egg.setTypeOfAnimal(item[numberOfAttr+1]);
							egg.setPasteurized(Boolean.parseBoolean(item[3]));
							fsList.add(egg);
						break;
							
						case FoodstuffClasses.FERMENTED:
							Fermented fermented = new Fermented();
							fermented.setName(foodstuff.getName());
							fermented.setNutrientContent(foodstuff.getNutrientContent());
							fermented.setNet(foodstuff.getNet());
							fermented.setNatural(Boolean.parseBoolean(item[numberOfAttr]));
							fermented.setAlcoholByVolume(Float.parseFloat(item[numberOfAttr+1]));
							fermented.setProduct(item[numberOfAttr+2]);
							fsList.add(fermented);
						break;
						
						case FoodstuffClasses.FISH:
							Fish fish = new Fish();
							fish.setName(foodstuff.getName());
							fish.setNutrientContent(foodstuff.getNutrientContent());
							fish.setNet(foodstuff.getNet());
							fish.setGmo(Boolean.parseBoolean(item[numberOfAttr]));
							fish.setTypeOfAnimal(item[numberOfAttr+1]);
							fish.setFishType(item[numberOfAttr+2]);
							fsList.add(fish);
						break;
							
						case FoodstuffClasses.FOODSTUFF:
							fsList.add(foodstuff);
						break;
						
						case FoodstuffClasses.FRUIT:
							Fruit fruit = new Fruit();
							fruit.setName(foodstuff.getName());
							fruit.setNutrientContent(foodstuff.getNutrientContent());
							fruit.setNet(foodstuff.getNet());
							fruit.setGmo(Boolean.parseBoolean(item[numberOfAttr]));
							fruit.setOrigin(item[numberOfAttr+1]);
							fruit.setDried(Boolean.parseBoolean(item[numberOfAttr+2]));
							fsList.add(fruit);
						break;
							
						case FoodstuffClasses.MEAT:
							Meat meat = new Meat();
							meat.setName(foodstuff.getName());
							meat.setNutrientContent(foodstuff.getNutrientContent());
							meat.setNet(foodstuff.getNet());
							meat.setGmo(Boolean.parseBoolean(item[numberOfAttr]));
							meat.setTypeOfAnimal(item[numberOfAttr+1]);
							meat.setColor(item[numberOfAttr+2]);
							fsList.add(meat);
						break;
						
						case FoodstuffClasses.PLANT:
							Plant plant = new Plant();
							plant.setName(foodstuff.getName());
							plant.setNutrientContent(foodstuff.getNutrientContent());
							plant.setNet(foodstuff.getNet());
							plant.setGmo(Boolean.parseBoolean(item[numberOfAttr]));
							plant.setOrigin(item[numberOfAttr+1]);
							fsList.add(plant);
						break;
							
						case FoodstuffClasses.SOFTDRINK:
							SoftDrink softDrink = new SoftDrink();
							softDrink.setName(foodstuff.getName());
							softDrink.setNutrientContent(foodstuff.getNutrientContent());
							softDrink.setNet(foodstuff.getNet());
							softDrink.setNatural(Boolean.parseBoolean(item[numberOfAttr]));
							softDrink.setCarbonated(Boolean.parseBoolean(item[numberOfAttr+1]));
							fsList.add(softDrink);
						break;
						
						case FoodstuffClasses.VEGETABLE:
							Vegetable vegetable = new Vegetable();
							vegetable.setName(foodstuff.getName());
							vegetable.setNutrientContent(foodstuff.getNutrientContent());
							vegetable.setNet(foodstuff.getNet());
							vegetable.setGmo(Boolean.parseBoolean(item[numberOfAttr]));
							vegetable.setOrigin(item[numberOfAttr+1]);
							vegetable.setUsedPart(item[numberOfAttr+2]);
							fsList.add(vegetable);
						break;	
				}
			}
		}
	}
	
	//може да изтриеш този ред
	//ако искаш да разбереш за какво е изтрий го и ще видиш, че се появява warning
	@SuppressWarnings("resource")
	private ArrayList<String[]> getAttributes(File file) {
		ArrayList<String[]> result = new ArrayList<>();
		//служи за прочитане съдържанието на файл (и не само)
		Scanner fileScanner;
		
		try {
			fileScanner = new Scanner(file);
			
			//в скобите се проверява дали има друг ред прочитане
			while (fileScanner.hasNextLine()) {
				//ако има: прочитаме този ред и чрез split вземаме
				//отделните атрибути - масив String[] и този масив го 
				//добавяме в списъка result
				result.add(fileScanner.nextLine().split(SPLITTER));
			}
			
			return result;
			
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
		
		return null;
	}
	
	private void printObejctsIntoTextArea() {
		//нулиране на съдържанието на текстовото поле
		taContent.setText("");

		//прочитаме всички обекти, записани в списъка
		//и печатаме информацията за всеки един в текстовото поле
		for (Foodstuff f : fsList) {
			taContent.append(f.toString());
		}
		//първият ред винаги е празен, за да го изтрием ползваме trim()
		taContent.setText(taContent.getText().trim());
	}

	//тази функция идва от това, че класът имплементира ActionListener
	//виж 20. ред
	@Override
	public void actionPerformed(ActionEvent e) {
		//ако е натиснат бутонът за отваряне на диалога
		if (e.getSource() == btnFile) {
			//отваряне на диалога
            int returnVal = fc.showOpenDialog(frame);
 
			//ако сме избрали някоя папка
            if (returnVal == JFileChooser.APPROVE_OPTION) {
				//записвам всички текстови файлове в този масив - files
            	files = fc.getSelectedFile().listFiles(new FilenameFilter() {
            	    public boolean accept(File dir, String name) {
            	        return name.toLowerCase().endsWith(".txt");
            	    }
            	});

				//бутонът "Покажи" вече може да натиска
                btnShow.setEnabled(true);
				//прочитаме съдържанието на файловете
                readFiles();
                
            }
			//ако не сме избрали нищо или сме натиснали Cancel
			else if (files == null) {
            	btnShow.setEnabled(false);
            }
		
		//ако е натиснат бутонът за печатане на данните
        } else if (e.getSource() == btnShow) {
			//извеждаме информацията от списъка с обектите в текстовото поле
        	printObejctsIntoTextArea();
        }
	}
	
	//създаваме обект от тип Foodstuff, като атрибутите му има стойностите посочени
	//в масива String[] attributes
	private Foodstuff getObject(String[] attributes) {
		
		if (attributes != null && attributes.length == numberOfAttr) {
			Foodstuff obj = new Foodstuff();
			
			obj.setName(attributes[0]);
			NutrientContent nutrientContent = new NutrientContent();
			nutrientContent.setWater(Float.parseFloat(attributes[1]));
			nutrientContent.setProteins(Float.parseFloat(attributes[2]));
			nutrientContent.setFat(Float.parseFloat(attributes[3]));
			nutrientContent.setCarbonhydrates(Float.parseFloat(attributes[4]));
			nutrientContent.setCalories(Float.parseFloat(attributes[5]));
			obj.setNutrientContent(nutrientContent);
			obj.setNet(Float.parseFloat(attributes[6]));
			
			return obj;
		}
		
		return null;
	}
}
