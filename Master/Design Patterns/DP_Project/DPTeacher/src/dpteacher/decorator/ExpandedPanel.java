package dpteacher.decorator;

import java.awt.GridLayout;
import javax.swing.JLabel;
import javax.swing.JTextField;

public class ExpandedPanel extends ExtensionPanel {
    private ExtensionPanel originalPanel = null;
    private JLabel lblPid;
    private JTextField tfPid;
    
    public ExpandedPanel() {
        myInitComponentsMethod();
    }
    
    public ExpandedPanel(ExtensionPanel panel) {
        this.originalPanel = panel;
        myInitComponentsMethod();
    }

    @Override
    public ExtensionPanel getDrawPanel() {
        return this.originalPanel;
    }
    
    public JTextField getPid() {
        return tfPid;
    }
    
    private void myInitComponentsMethod() {
        lblPid = new javax.swing.JLabel();
        tfPid = new javax.swing.JTextField(15);
        lblPid.setText("Personal ID:");
        originalPanel.setLayout(new GridLayout(1, 2));
        originalPanel.add(lblPid);
        originalPanel.add(tfPid);
    }
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 120, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 92, Short.MAX_VALUE)
        );
    }// </editor-fold>//GEN-END:initComponents


    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
}
