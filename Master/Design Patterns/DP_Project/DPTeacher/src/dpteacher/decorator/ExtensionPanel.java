package dpteacher.decorator;

public class ExtensionPanel extends javax.swing.JPanel {

    public static final int MYPANEL_EXPANDED    = 1;
    public static final int MYPANEL_COMPACT     = 2;

    /** Creates new form ExtensionPanel */
    public ExtensionPanel() {
        initComponents();       
        this.setLayout(new java.awt.GridLayout(1, 2));
    }

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {
    }// </editor-fold>//GEN-END:initComponents

    public ExtensionPanel getDrawPanel() {
        return this;
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables

}
