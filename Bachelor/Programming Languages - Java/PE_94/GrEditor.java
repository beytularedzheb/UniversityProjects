import java.awt.*;
import java.awt.event.*;
import java.util.HashMap;
import java.util.Map.Entry;

import javax.swing.*;


public class GrEditor {
	JFrame f;
	JPanel drawPanel, menuPanel;
	JRadioButton fOval, fRect, oOval; 
	JTextField x, y, w, h;
	Color drawCol, fillCol;
	JComboBox<String> colList, fColList;
	HashMap<Integer, Shape> hm;
	int curObj;
	static int key;
	

	GrEditor() {
		f = new JFrame("�������� ��������");
		f.setLayout(null);
		f.setSize(1024, 768);
		f.setResizable(false);
		f.setBackground(new Color(170, 170, 170));
		f.addWindowListener(new WindowAdapter () {
			public void windowClosing(WindowEvent e) {
				System.exit(0);
			}
		});
		
		key = Integer.MAX_VALUE; 
		
		curObj = 0;
		drawCol = fillCol = Color.black;
		final R r = new R();
		r.setBounds(7, 85, 1005, 625);
		r.setBackground(Color.white);
		f.add(r);
		
		
		drawPanel = new JPanel();
		drawPanel.setBounds(0, 0, f.getWidth(), 35);
		f.add(drawPanel);
	
		oOval = new JRadioButton("���������� ����");
		fOval = new JRadioButton("�������� ����");
		fRect = new JRadioButton("�������� �������������");
		
		ButtonGroup group = new ButtonGroup();
		group.add(oOval);
		group.add(fOval);
		group.add(fRect);
		group.setSelected(oOval.getModel(), true);
		
		colList = new JComboBox<String>();
		fColList = new JComboBox<String>();
		
		oOval.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				curObj = 0;
				fColList.setEnabled(false);
			}
		});
		fOval.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				curObj = 1;
				fColList.setEnabled(true);
			}
		});
		fRect.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				curObj = 2;
				fColList.setEnabled(true);
			}
		});

		drawPanel.add(oOval);
		drawPanel.add(fOval);
		drawPanel.add(fRect);
		
		colList.addItem("�����");
		colList.addItem("���");
		colList.addItem("�����");
		colList.addItem("������");
		colList.addItem("����");
		colList.addItemListener(new ItemListener() {
			public void itemStateChanged(ItemEvent ee) {
				String clickedItem = (String) colList.getSelectedItem();
				if (clickedItem.equals("�����")) drawCol = Color.black;
				else if (clickedItem.equals("���")) drawCol = Color.blue;
				else if (clickedItem.equals("�����")) drawCol = Color.green;
				else if (clickedItem.equals("������")) drawCol = Color.red;
				else if (clickedItem.equals("����")) drawCol = Color.yellow;
				else drawCol = Color.cyan;				
			}
		});
		drawPanel.add(colList);
		drawPanel.add(new JLabel("���� �� �����������"));

		fColList.addItem("�����");
		fColList.addItem("���");
		fColList.addItem("�����");
		fColList.addItem("������");
		fColList.addItem("����");
		fColList.addItemListener(new ItemListener() {
			public void itemStateChanged(ItemEvent ee) {
				String clickedItem = (String) fColList.getSelectedItem();
				if (clickedItem.equals("�����")) fillCol = Color.black;
				else if (clickedItem.equals("���")) fillCol = Color.blue;
				else if (clickedItem.equals("�����")) fillCol = Color.green;
				else if (clickedItem.equals("������")) fillCol = Color.red;
				else if (clickedItem.equals("����")) fillCol = Color.yellow;
				else fillCol = Color.cyan;
			}
		});
		drawPanel.add(fColList);
		drawPanel.add(new JLabel("���� �� ���������"));
		
		menuPanel = new JPanel();
		menuPanel.setBounds(0, 35, f.getWidth(), 33);
		Label xL = new Label("������� �� X:");
		menuPanel.add(xL);
		x =  new JTextField(5);
		menuPanel.add(x);
		Label yL = new Label("������� �� Y:");
		menuPanel.add(yL);
		y =  new JTextField(5);
		menuPanel.add(y);		
		Label wL = new Label("��������:");
		menuPanel.add(wL);
		w =  new JTextField(5);
		menuPanel.add(w);		
		Label hL = new Label("��������:");
		menuPanel.add(hL);
		h =  new JTextField(5);
		menuPanel.add(h);
		
		
		hm = new HashMap<Integer, Shape>();
		
		JButton btnDraw = new JButton("��������");
		btnDraw.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				int a, b, c, d;
				try {
					a = Integer.parseInt(x.getText());
					b = Integer.parseInt(y.getText());
					c = Integer.parseInt(w.getText());
					d = Integer.parseInt(h.getText());
					
					if (a > 1005 || a < 0) 
						JOptionPane.showMessageDialog(f, "���� �������� ���� ����� ����� 0 � 1005 �� �1");
					else if (b > 625 || b < 0)
						JOptionPane.showMessageDialog(f, "���� �������� ���� ����� ����� 0 � 625 �� Y1");
					else if (c > 1005 || (c + a) > 1005 || c < 0)
						JOptionPane.showMessageDialog(f, "���� �������� ���� � �������� ����� �� ����������");
					else if (d > 625 || (d + b) > 625 || d < 0)
						JOptionPane.showMessageDialog(f, "���� �������� ���� � �������� ����� �� ����������");
					else if (curObj == -1)
						JOptionPane.showMessageDialog(f, "���� �������� ��������.");
					else {
						if (curObj == 0)
							hm.put(key, new Oval(a, b, c, d, drawCol));
						else if (curObj == 1)
							hm.put(key, new FilledOval(a, b, c, d, drawCol, fillCol)); 
						else if (curObj == 2)
							hm.put(key, new FilledRect(a, b, c, d, drawCol, fillCol));					
					key--;
					x.setText(null); y.setText(null);
					w.setText(null); h.setText(null);
					r.repaint();
					}
				}				
				catch(Exception exc){
					JOptionPane.showMessageDialog(f, "������ ��� ����������� ��������!");
				}
			}
		});
		menuPanel.add(btnDraw);		
		
		JButton btnArrToConsole = new JButton("������ ������� �� ���������");
		btnArrToConsole.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				for (Entry<Integer, Shape> me : hm.entrySet()) 
					System.out.println("����: " + me.getKey() + ", ��������: " + me.getValue().getClass());
				System.out.println();
			}
		});	
		menuPanel.add(btnArrToConsole);
		
		
		f.add(menuPanel);
		f.setVisible(true);
	}
	
	
	class R extends Canvas {
		private static final long serialVersionUID = 1L;

		public void paint(Graphics g) {
			for (Entry<Integer, Shape> me : hm.entrySet())
				me.getValue().drawShape(g);			
		}	
	}	

	public static void main(String[] args) {
		new GrEditor();
	}
}