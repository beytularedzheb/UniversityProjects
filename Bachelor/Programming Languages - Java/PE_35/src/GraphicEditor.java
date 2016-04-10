import java.awt.Button;
import java.awt.Checkbox;
import java.awt.CheckboxGroup;
import java.awt.Choice;
import java.awt.Color;
import java.awt.Frame;
import java.awt.Panel;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;


public class GraphicEditor {
	private Frame mainFrame, drawFrame;
	private Choice bgColorList, borderColorList;
	private Button btnToConsole;
	private Checkbox lLine, fOval, oOval;
	private DrawingField drawField;
	private Panel toolsPanel;
	
	private GraphicEditor()
	{
		mainFrame = new Frame("Векторен графичен редактор");
		mainFrame.setLayout(null);
		mainFrame.setBounds(0, 0, 400, 160);
		mainFrame.setResizable(false);
		mainFrame.addWindowListener(new WindowAdapter () {
			public void windowClosing(WindowEvent e) {
				System.exit(0);
			}
		});
		
		drawField = new DrawingField();
		
		toolsPanel = new Panel(null);
		toolsPanel.setBounds(10, 35, 380, 115);
		toolsPanel.setBackground(new Color(245, 245, 245));
		mainFrame.add(toolsPanel);
		
		CheckboxGroup group = new CheckboxGroup();
		lLine = new Checkbox("Линия", group, false);
		lLine.setBounds(0, 0, 200, 25);
		fOval = new Checkbox("Запълнен овал", group, false);
		fOval.setBounds(0, 25, 200, 25);
		oOval = new Checkbox("Незапълнен овал", group, false);
		oOval.setBounds(0, 50, 200, 25);
		
		lLine.addItemListener(new ItemListener() {
			public void itemStateChanged(ItemEvent e) {
				drawField.selectedShape = 1;
			}
		});
		fOval.addItemListener(new ItemListener() {
			public void itemStateChanged(ItemEvent e) {
				drawField.selectedShape = 2;
			}
		});
		oOval.addItemListener(new ItemListener() {
			public void itemStateChanged(ItemEvent e) {
				drawField.selectedShape = 3;
			}
		});
		
		toolsPanel.add(lLine);
		toolsPanel.add(fOval);
		toolsPanel.add(oOval);
		
		drawFrame = new Frame("Векторен графичен редактор");
		drawFrame.setBounds(mainFrame.getBounds().x, 
				mainFrame.getBounds().y + mainFrame.getBounds().height, 600, 400);
		drawFrame.setResizable(false);

		drawField.setBackground(Color.white);
		drawFrame.add(drawField);
		
		bgColorList = new Choice();
		bgColorList.setBounds(230, 40, 150, 30);
		bgColorList.addItem("Черен");
		bgColorList.addItem("Син");
		bgColorList.addItem("Зелен");
		bgColorList.addItem("Червен");
		bgColorList.addItem("Жълт");
		bgColorList.addItemListener(new ItemListener() {
			public void itemStateChanged(ItemEvent ee) {
				String clickedItem = (String) bgColorList.getSelectedItem();
				if (clickedItem.equals("Черен")) drawField.bgColor = Color.black;
				else if (clickedItem.equals("Син")) drawField.bgColor = Color.blue;
				else if (clickedItem.equals("Зелен")) drawField.bgColor = Color.green;
				else if (clickedItem.equals("Червен")) drawField.bgColor = Color.red;
				else if (clickedItem.equals("Жълт")) drawField.bgColor = Color.yellow;				
			}
		});
		toolsPanel.add(bgColorList);
		
		borderColorList = new Choice();
		borderColorList.setBounds(230, 0, 150, 30);
		borderColorList.addItem("Черен");
		borderColorList.addItem("Син");
		borderColorList.addItem("Зелен");
		borderColorList.addItem("Червен");
		borderColorList.addItem("Жълт");
		borderColorList.addItemListener(new ItemListener() {
			public void itemStateChanged(ItemEvent ee) {
				String clickedItem = (String) borderColorList.getSelectedItem();
				if (clickedItem.equals("Черен")) drawField.borderColor = Color.black;
				else if (clickedItem.equals("Син")) drawField.borderColor = Color.blue;
				else if (clickedItem.equals("Зелен")) drawField.borderColor = Color.green;
				else if (clickedItem.equals("Червен")) drawField.borderColor = Color.red;
				else if (clickedItem.equals("Жълт")) drawField.borderColor = Color.yellow;				
			}
		});
		toolsPanel.add(borderColorList);
		
		btnToConsole = new Button("Конзола");
		btnToConsole.setBounds(230, 80, 150, 30);
		btnToConsole.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				System.out.println();
				for (int i = 0; i < drawField.index; i++) {
					System.out.println(drawField.shapes[i].getClass());
				}
			}
		});
		toolsPanel.add(btnToConsole);
		
		drawFrame.setVisible(true);
		
		mainFrame.setVisible(true);
	}
	
	public static void main(String[] args) {
		new GraphicEditor();
	}
}