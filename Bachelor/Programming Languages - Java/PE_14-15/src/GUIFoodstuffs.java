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
	
	//����� �������, ������� � ������� ���� �� �������
	//�� ������� � ���� ���� ":" - ������ ����� ����
	// �������� Dairy.txt, �� �� �� � ��-����
	private final String SPLITTER = ":";
	
	//����� �� ������� - ������� ������ ������� �� ���������
	//���������� - Dairy.txt, Distilled.txt � �.�.
	private File[] files;
	//���������� ����, � ����� �� �������� �������
	private JTextArea taContent;
	//������� �� �������� �� ������� �� ����� �� �����
	private JButton btnFile;
	//�������, � ����� �� �������� ������� � ���������� ����
	private JButton btnShow;
	//�������� �� ����� �� ������� � ���������
	private JFileChooser fc;
	//���������� �� ������������
	private JFrame frame;
	
	//��������, � ����� �� �������� ������ ������,
	//��������� �� ���������� �������
	private ArrayList<Foodstuff> fsList;
	//��������� ���� �� ���������� �� ����� Foodstuff
	private int numberOfAttr;
	
	//������������� �� �����
	public GUIFoodstuffs(String title) {
		//��������� �� �������
		fsList = new ArrayList<>();
		//��������� �� ����������� �� JavaCodebaseComponent
		//��� ������� ���� ��� ��� ������� false ������������
		//�� �������� ���� windows app - �������, �������� �� ����������, ����� � �.�.
		JFrame.setDefaultLookAndFeelDecorated(true);
		//��������� �� ���������
		frame = new JFrame(title);
		//������ �������� X � ������-����� ���� ������������ �����
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//�������� ���� �� Layout'a �� ���������, �� ����� �����
		//���������� � ��������� �� �� �����������(���������)
		frame.getContentPane().setLayout(new BorderLayout());
		
		//��������� �� ������� �� ����� �� ������� � ���������
		fc = new JFileChooser();
		fc.setCurrentDirectory(new java.io.File("."));
	    fc.setDialogTitle("�������� ����������");
		//�� ������ � ���� ������ �� ������� �������, � �� �����, ��
		//���� �� �� ������� ���� �� �� �� ������ ���� ����� - DIRECTORIES_ONLY
	    fc.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
		//���� ���� ������� ������� ��� ����, �� ����� ������� ����
		//�� �����, �� ������������ ���� All Files - ������� ��� �� ����
	    fc.setAcceptAllFileFilterUsed(false);
		
		
		/***********************************************************************/
		//��������� �� ������, � ����� �� �� ����������� ����� ������
		//GridLayout(0, 2) - "0" ���� � 2 ������
		JPanel pnlButtons = new JPanel(new GridLayout(0, 2));
		
		//��������� �� ������ �� �������� �� �������
		btnFile = new JButton("��������� �� ����� �� ����");
		//�������� �� �������� - �������, ����� �� ���� ����������
		//�� �������� ���� ������� � �������� � ������������ �� ��������
		//���� - � ������ �������� �������
		btnFile.addActionListener(this);
		//�������� �� ������ � ������
		pnlButtons.add(btnFile);
        
        btnShow = new JButton("������");
        btnShow.addActionListener(this);
		//������������ ���� ����� � �����������,�.�.
		//�� ���� �� �� ������ (������)
        btnShow.setEnabled(false);
        pnlButtons.add(btnShow);
        
		//�������� �� ������ � ���������
        frame.getContentPane().add(pnlButtons, BorderLayout.PAGE_START);
        /***********************************************************************/
        
        
        /***********************************************************************/
        //��������� �� ������, � ����� �� ��� �������� ����
		JPanel pnlContent = new JPanel(new BorderLayout());
        
		//��������� �� ���������� ����
        taContent = new JTextArea();
        
		//��������� �� ���� � ���������� �� ���������� � � ���� �����
		//�������� ���������� ����, ������ ���������� �� ��������� 
		//� ������ ����������
        JScrollPane scroll = new JScrollPane (taContent, 
        	JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
        
		//�������� �� ����� ������ � �������� �����
        pnlContent.add(scroll, BorderLayout.CENTER);
        
		//�������� �� ����� � ���������
        frame.getContentPane().add(pnlContent, BorderLayout.CENTER);
        /***********************************************************************/
        
        //�� ��� ������� ����� ����� �����, �� ��� setSize �
		//����� ���� ���������� ������ � ������� ����� �������
		frame.pack();
		//�������� ������� �� ���������
		frame.setSize(500, 500);
		//���������� �� �� ���� �� �� ����������
		frame.setResizable(false);
		//�� �� ������� � ������� �� ������
		frame.setLocationRelativeTo(null);
		//���������� �� ������������ � �������, ������� ��� �� ����� �����
        frame.setVisible(true);
	}
	
	private void readFiles() {
		//�������� �� ������� � �������
		fsList.clear();
		
		//������� ���� �� ���������� �� ����� Foodstuff. -1 ������
		//NutrientContent � ���� ���� � 5 ��������
		numberOfAttr = Foodstuff.class.getDeclaredFields().length - 1; // minus 1 NutrientContent
		numberOfAttr += NutrientContent.class.getDeclaredFields().length;
		
		//��������� ������������ �� ��������� �������, 1 �� 1
		for (File file : files) {
			//�.� ������ ������� �������� ���������� �� Foodstuff � ��� ����������� �� ����
			//����������� �� ������� numberOfAttr �������� �� ����� ���
			//���� ������ ������� ������� �� ���� �������, ������� �� �������� � ������� ����
			//�������� � Distilled.txt ��� 2 ������ (2 ����)
			ArrayList<String[]> objectsAttr = getAttributes(file);
			//�����, � ����� �� ������� ������� ������
			for (String[] item : objectsAttr) {
					//��������� �� ������� numberOfAttr �������� � �����
					Foodstuff foodstuff = 
							getObject(Arrays.copyOfRange(item, 0, numberOfAttr));
					
					//�������� ����� �� ����� �� ������������ �� - Distilled.txt -> distilled
					//������������ ������� ��������� ������ �� ��������� �� ������� �� ��������� (� ������) ���
					//������� ���� � FoodstuffClasses.java - ��� ��!
					String fileName = file.getName().substring(0, file.getName().
							length() - ".txt".length()).toLowerCase();
					
					//����������� ����� ����� �����: ��� fileName e distilled, ��
					// �� �� �������� "case FoodstuffClasses.DISTILLED"
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
							//��������� ����� �� ��� Distilled
							Distilled distilled = new Distilled();
							//�������� ����������� �� ���������� ��
							distilled.setName(foodstuff.getName());
							distilled.setNutrientContent(foodstuff.getNutrientContent());
							distilled.setNet(foodstuff.getNet());
							distilled.setNatural(Boolean.parseBoolean(item[numberOfAttr]));
							distilled.setAlcoholByVolume(Float.parseFloat(item[numberOfAttr+1]));
							distilled.setAroma(item[numberOfAttr+2]);
							//�������� distilled � �������
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
	
	//���� �� ������� ���� ���
	//��� ����� �� �������� �� ����� � ������ �� � �� �����, �� �� ������� warning
	@SuppressWarnings("resource")
	private ArrayList<String[]> getAttributes(File file) {
		ArrayList<String[]> result = new ArrayList<>();
		//����� �� ��������� ������������ �� ���� (� �� ����)
		Scanner fileScanner;
		
		try {
			fileScanner = new Scanner(file);
			
			//� ������� �� ��������� ���� ��� ���� ��� ���������
			while (fileScanner.hasNextLine()) {
				//��� ���: ��������� ���� ��� � ���� split �������
				//��������� �������� - ����� String[] � ���� ����� �� 
				//�������� � ������� result
				result.add(fileScanner.nextLine().split(SPLITTER));
			}
			
			return result;
			
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
		
		return null;
	}
	
	private void printObejctsIntoTextArea() {
		//�������� �� ������������ �� ���������� ����
		taContent.setText("");

		//��������� ������ ������, �������� � �������
		//� �������� ������������ �� ����� ���� � ���������� ����
		for (Foodstuff f : fsList) {
			taContent.append(f.toString());
		}
		//������� ��� ������ � ������, �� �� �� ������� �������� trim()
		taContent.setText(taContent.getText().trim());
	}

	//���� ������� ���� �� ����, �� ������ ������������ ActionListener
	//��� 20. ���
	@Override
	public void actionPerformed(ActionEvent e) {
		//��� � �������� ������� �� �������� �� �������
		if (e.getSource() == btnFile) {
			//�������� �� �������
            int returnVal = fc.showOpenDialog(frame);
 
			//��� ��� ������� ����� �����
            if (returnVal == JFileChooser.APPROVE_OPTION) {
				//�������� ������ �������� ������� � ���� ����� - files
            	files = fc.getSelectedFile().listFiles(new FilenameFilter() {
            	    public boolean accept(File dir, String name) {
            	        return name.toLowerCase().endsWith(".txt");
            	    }
            	});

				//������� "������" ���� ���� �� �������
                btnShow.setEnabled(true);
				//��������� ������������ �� ���������
                readFiles();
                
            }
			//��� �� ��� ������� ���� ��� ��� ��������� Cancel
			else if (files == null) {
            	btnShow.setEnabled(false);
            }
		
		//��� � �������� ������� �� �������� �� �������
        } else if (e.getSource() == btnShow) {
			//��������� ������������ �� ������� � �������� � ���������� ����
        	printObejctsIntoTextArea();
        }
	}
	
	//��������� ����� �� ��� Foodstuff, ���� ���������� �� ��� ����������� ��������
	//� ������ String[] attributes
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
