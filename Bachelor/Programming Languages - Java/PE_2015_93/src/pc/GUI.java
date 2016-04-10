package pc;

import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileNotFoundException;

import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.filechooser.FileFilter;
import javax.swing.filechooser.FileNameExtensionFilter;

import components.pc.*;

public class GUI implements ActionListener {

	public static final String OBJECT_DELIMITER = "*#*#*#*";
	
	private File file;
	private JTextArea taContent;
	private JButton btnOpen;
	private JButton btnShow;
	private JFileChooser fc;
	private JFrame frame;
	
	private Component[] arr;
	
	public GUI(String title) {
		
		frame = new JFrame(title);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(new BorderLayout());
		
		fc = new JFileChooser();
		FileFilter fileFilter = new FileNameExtensionFilter("Text File", "txt");
		fc.setFileFilter(fileFilter);
		
		
		/***********************************************************************/
		JPanel pnlButtons = new JPanel(new GridLayout(0, 2));
		
		btnOpen = new JButton("Open");
		btnOpen.addActionListener(this);
		pnlButtons.add(btnOpen);
        
        btnShow = new JButton("Show");
        btnShow.addActionListener(this);
        btnShow.setEnabled(false);
        pnlButtons.add(btnShow);
              
        frame.getContentPane().add(pnlButtons, BorderLayout.PAGE_START);
        /***********************************************************************/
        
        
        /***********************************************************************/
        JPanel pnlContent = new JPanel(new BorderLayout());
        
        taContent = new JTextArea();
        
        JScrollPane scroll = new JScrollPane (taContent, 
        	JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
        
        pnlContent.add(scroll, BorderLayout.CENTER);
        
        frame.getContentPane().add(pnlContent, BorderLayout.CENTER);
        /***********************************************************************/
        
        
		frame.pack();
		frame.setSize(520, 450);
		frame.setResizable(false);
		frame.setLocationRelativeTo(null);
        frame.setVisible(true);
	}
	
	private void printObejctsIntoTextArea() {
		taContent.setText("");
		int count = 0;
		
		for (Component f : arr) {
			taContent.append("[" + ++count + "] ");
			taContent.append(f.toString());
			taContent.append("\r\n");
		}
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		if (e.getSource() == btnOpen) {
            int returnVal = fc.showOpenDialog(frame);
 
            if (returnVal == JFileChooser.APPROVE_OPTION) {
                file = fc.getSelectedFile();
                btnShow.setEnabled(true);
                readFile();
                
            } else if (file == null) {
            	btnShow.setEnabled(false);
            }
        } else if (e.getSource() == btnShow) {
        	printObejctsIntoTextArea();
        }
	}
	
	private void readFile() {
		if (file != null && !file.getName().isEmpty()) {
			java.util.Scanner fileScanner;
			try {
				fileScanner = new java.util.Scanner(file);
				int objCounter = 0;
				
				while (fileScanner.hasNextLine()) {
					if (fileScanner.nextLine().compareTo(OBJECT_DELIMITER) == 0) {
						objCounter++;
					}
				}
				
				if (objCounter > 0) {
					arr = new Component[objCounter];
					objCounter = -1;
					fileScanner = new java.util.Scanner(file);
					boolean newObject = false;
					String line;
					int c = 0;
					
					while (fileScanner.hasNextLine()) {
						line = fileScanner.nextLine();
						
						if (line.compareTo(OBJECT_DELIMITER) == 0) {
							newObject = true;
							objCounter++;
							continue;
						}
						
						if (newObject == true) {
							c = 0;
							newObject = false;
							
							switch (line) {
								case PCComponents.CAMERA:
									Camera camera = new Camera();

									while (fileScanner.hasNext()) {
										if (c == 0) { camera.setName(fileScanner.nextLine()); }
										else if (c == 1) { camera.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { camera.setModalityOfInput(fileScanner.nextLine()); }
										else if (c == 3) { camera.setResolution(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = camera;
								break;
								case PCComponents.COMPONENT:
									Component component = new Component();

									while (fileScanner.hasNext()) {
										if (c == 0) { component.setName(fileScanner.nextLine()); }
										else break;
										c++;
									}
									arr[objCounter] = component;
								break;
								case PCComponents.CPU:
									CPU cpu = new CPU();

									while (fileScanner.hasNext()) {
										if (c == 0) { cpu.setName(fileScanner.nextLine()); }
										else if (c == 1) { cpu.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { cpu.setMemoryCapacity(Float.parseFloat(fileScanner.nextLine())); }
										else if (c == 3) { cpu.setCacheLevels(Integer.parseInt(fileScanner.nextLine())); }
										else if (c == 4) { cpu.setNumberOfCores(Integer.parseInt(fileScanner.nextLine())); }
										else if (c == 5) { cpu.setClockSpeed(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = cpu;
								break;
								case PCComponents.EXTERNAL:
									External external = new External();

									while (fileScanner.hasNext()) {
										if (c == 0) { external.setName(fileScanner.nextLine()); }
										else if (c == 1) { external.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = external;
								break;
								case PCComponents.FAN:
									Fan fan = new Fan();

									while (fileScanner.hasNext()) {
										if (c == 0) { fan.setName(fileScanner.nextLine()); }
										else if (c == 1) { fan.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { fan.setRotationalSpeed(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = fan;
								break;
								case PCComponents.FLASH_DRIVE:
									FlashDrive fd = new FlashDrive();

									while (fileScanner.hasNext()) {
										if (c == 0) { fd.setName(fileScanner.nextLine()); }
										else if (c == 1) { fd.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { fd.setModalityOfIO(fileScanner.nextLine()); }
										else if (c == 3) { fd.setCapacity(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = fd;
								break;
								case PCComponents.HDD:
									HDD hdd = new HDD();

									while (fileScanner.hasNext()) {
										if (c == 0) { hdd.setName(fileScanner.nextLine()); }
										else if (c == 1) { hdd.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { hdd.setMemoryCapacity(Float.parseFloat(fileScanner.nextLine())); }
										else if (c == 3) { hdd.setLatency(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = hdd;
								break;
								case PCComponents.INPUT_DEVICE:
									InputDevice id = new InputDevice();

									while (fileScanner.hasNext()) {
										if (c == 0) { id.setName(fileScanner.nextLine()); }
										else if (c == 1) { id.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { id.setModalityOfInput(fileScanner.nextLine()); }
										else break;
										c++;
									}
									arr[objCounter] = id;
								break;
								case PCComponents.INTERACTIVE_MONITOR:
									InteractiveMonitor im = new InteractiveMonitor();

									while (fileScanner.hasNext()) {
										if (c == 0) { im.setName(fileScanner.nextLine()); }
										else if (c == 1) { im.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { im.setModalityOfIO(fileScanner.nextLine()); }
										else if (c == 3) { im.setTouchPoints(Integer.parseInt(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = im;
								break;
								case PCComponents.INTERNAL:
									Internal internal = new Internal();

									while (fileScanner.hasNext()) {
										if (c == 0) { internal.setName(fileScanner.nextLine()); }
										else if (c == 1) { internal.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = internal;
								break;
								case PCComponents.IO_DEVICE:
									IODevice iod = new IODevice();

									while (fileScanner.hasNext()) {
										if (c == 0) { iod.setName(fileScanner.nextLine()); }
										else if (c == 1) { iod.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { iod.setModalityOfIO(fileScanner.nextLine()); }
										else break;
										c++;
									}
									arr[objCounter] = iod;
								break;
								case PCComponents.KEYBOARD:
									Keyboard kb = new Keyboard();

									while (fileScanner.hasNext()) {
										if (c == 0) { kb.setName(fileScanner.nextLine()); }
										else if (c == 1) { kb.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { kb.setModalityOfInput(fileScanner.nextLine()); }
										else if (c == 3) { kb.setCountryLayout(fileScanner.nextLine()); }
										else if (c == 4) { kb.setIntegratedTrackball(Boolean.parseBoolean(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = kb;
								break;
								case PCComponents.MICROPHONE:
									Microphone mp = new Microphone();

									while (fileScanner.hasNext()) {
										if (c == 0) { mp.setName(fileScanner.nextLine()); }
										else if (c == 1) { mp.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { mp.setModalityOfInput(fileScanner.nextLine()); }
										else if (c == 3) { mp.setPickUpPattern(fileScanner.nextLine()); }
										else break;
										c++;
									}
									arr[objCounter] = mp;
								break;
								case PCComponents.MONITOR:
									Monitor mon = new Monitor();

									while (fileScanner.hasNext()) {
										if (c == 0) { mon.setName(fileScanner.nextLine()); }
										else if (c == 1) { mon.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { mon.setNumberOfColors(Integer.parseInt(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = mon;
								break;
								case PCComponents.MOTHERBOARD:
									MotherBoard mb = new MotherBoard();

									while (fileScanner.hasNext()) {
										if (c == 0) { mb.setName(fileScanner.nextLine()); }
										else if (c == 1) { mb.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { mb.setCpuSocket(fileScanner.nextLine()); }
										else break;
										c++;
									}
									arr[objCounter] = mb;
								break;
								case PCComponents.MOUSE:
									Mouse mo = new Mouse();

									while (fileScanner.hasNext()) {
										if (c == 0) { mo.setName(fileScanner.nextLine()); }
										else if (c == 1) { mo.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { mo.setModalityOfInput(fileScanner.nextLine()); }
										else if (c == 3) { mo.setSensitivity(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = mo;
								break;
								case PCComponents.MULTIFUNCTION_PRINTER:
									MultifunctionPrinter mup = new MultifunctionPrinter();

									while (fileScanner.hasNext()) {
										if (c == 0) { mup.setName(fileScanner.nextLine()); }
										else if (c == 1) { mup.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { mup.setModalityOfIO(fileScanner.nextLine()); }
										else if (c == 3) { mup.setIncludedDevices(fileScanner.nextLine()); }
										else break;
										c++;
									}
									arr[objCounter] = mup;
								break;
								case PCComponents.OUTPUT_DEVICE:
									OutputDevice od = new OutputDevice();

									while (fileScanner.hasNext()) {
										if (c == 0) { od.setName(fileScanner.nextLine()); }
										else if (c == 1) { od.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { od.setModalityOfOutput(fileScanner.nextLine()); }
										else break;
										c++;
									}
									arr[objCounter] = od;
								break;
								case PCComponents.PRINTER:
									Printer p = new Printer();

									while (fileScanner.hasNext()) {
										if (c == 0) { p.setName(fileScanner.nextLine()); }
										else if (c == 1) { p.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { p.setModalityOfOutput(fileScanner.nextLine()); }
										else if (c == 3) { p.setMonochrome(Boolean.parseBoolean(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = p;
								break;
								case PCComponents.RAM:
									RAM ram = new RAM();

									while (fileScanner.hasNext()) {
										if (c == 0) { ram.setName(fileScanner.nextLine()); }
										else if (c == 1) { ram.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { ram.setMemoryCapacity(Float.parseFloat(fileScanner.nextLine())); }
										else if (c == 3) { ram.setFrequency(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = ram;
								break;
								case PCComponents.SCANNER:
									Scanner sc = new Scanner();

									while (fileScanner.hasNext()) {
										if (c == 0) { sc.setName(fileScanner.nextLine()); }
										else if (c == 1) { sc.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { sc.setModalityOfInput(fileScanner.nextLine()); }
										else if (c == 3) { sc.setResolution(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = sc;
								break;
								case PCComponents.SOUND_CARD:
									SoundCard soc = new SoundCard();

									while (fileScanner.hasNext()) {
										if (c == 0) { soc.setName(fileScanner.nextLine()); }
										else if (c == 1) { soc.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { soc.setChannel(fileScanner.nextLine()); }
										else break;
										c++;
									}
									arr[objCounter] = soc;
								break;
								case PCComponents.SPEACKER:
									Speacker sp = new Speacker();

									while (fileScanner.hasNext()) {
										if (c == 0) { sp.setName(fileScanner.nextLine()); }
										else if (c == 1) { sp.setWired(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { sp.setModalityOfOutput(fileScanner.nextLine()); }
										else break;
										c++;
									}
									arr[objCounter] = sp;
								break;
								case PCComponents.VIDEO_CARD:
									VideoCard vc = new VideoCard();

									while (fileScanner.hasNext()) {
										if (c == 0) { vc.setName(fileScanner.nextLine()); }
										else if (c == 1) { vc.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { vc.setMemoryCapacity(Float.parseFloat(fileScanner.nextLine())); }
										else if (c == 2) { vc.setBandwidth(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = vc;
								break;
								case PCComponents.WITH_MEMORY:
									WithMemory wm = new WithMemory();

									while (fileScanner.hasNext()) {
										if (c == 0) { wm.setName(fileScanner.nextLine()); }
										else if (c == 1) { wm.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else if (c == 2) { wm.setMemoryCapacity(Float.parseFloat(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = wm;
								break;
								case PCComponents.WITHOUT_MEMORY:
									WithoutMemory wom = new WithoutMemory();

									while (fileScanner.hasNext()) {
										if (c == 0) { wom.setName(fileScanner.nextLine()); }
										else if (c == 1) { wom.setPrimary(Boolean.parseBoolean(fileScanner.nextLine())); }
										else break;
										c++;
									}
									arr[objCounter] = wom;
								break;
								default:
									taContent.setText("Error!");
									System.out.println("Error!");
									break;
							}
						}
					}
				}
			} catch (FileNotFoundException e) {
				e.printStackTrace();
			}
		}
	}

}
