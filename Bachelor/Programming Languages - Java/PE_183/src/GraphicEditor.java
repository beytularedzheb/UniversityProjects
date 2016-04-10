import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JPanel;


public class GraphicEditor {
	private JFrame mainFrame, drawFrame;
	private JComboBox<String> bgColorList, borderColorList, btnShape;
	private JButton btnToConsole;
	private DrawingField drawField;
	private JPanel toolsPanel;
	
	private GraphicEditor()
	{
		mainFrame = new JFrame("Векторен графичен редактор");
		mainFrame.setLayout(null);
		mainFrame.setBounds(0, 0, 400, 110);
		mainFrame.setResizable(false);
		mainFrame.setDefaultCloseOperation(3);
		
		drawField = new DrawingField();
		
		toolsPanel = new JPanel(null);
		toolsPanel.setBounds(5, 5, 380, 115);
		mainFrame.add(toolsPanel);
		
		drawFrame = new JFrame("Векторен графичен редактор");
		drawFrame.setLayout(null);
		drawFrame.setBounds(mainFrame.getBounds().x, 
				mainFrame.getBounds().y + mainFrame.getBounds().height, 750, 500);
		drawFrame.setResizable(false);
		drawFrame.setDefaultCloseOperation(0);

		drawField.setBounds(5, 5, drawFrame.getBounds().width - 15, drawFrame.getBounds().height - 40);
		drawField.setBackground(Color.white);
		drawFrame.add(drawField);
		
		btnShape = new JComboBox<String>();
		btnShape.setBounds(5, 0, 200, 30);
		btnShape.addItem("Незапълнен четириъгълник");
		btnShape.addItem("Запълнен четириъгълник");
		btnShape.addItem("Незапълнен овал");
		btnShape.addItemListener(new ItemListener() {
			public void itemStateChanged(ItemEvent e) {
				drawField.selectedShape = (byte) btnShape.getSelectedIndex();			
			}
		});
		toolsPanel.add(btnShape);
		
		bgColorList = new JComboBox<String>();
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
		
		borderColorList = new JComboBox<String>();
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
		
		btnToConsole = new JButton("Конзола");
		btnToConsole.setBounds(5, 40, 150, 30);
		btnToConsole.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				System.out.println();
				for(int i = 0; i < drawField.shapes.size(); i++) {
					System.out.println(drawField.shapes.get(i).getClass().getName());
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