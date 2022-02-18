import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Shell;
import org.eclipse.swt.widgets.Button;
import org.eclipse.swt.SWT;
import org.eclipse.swt.widgets.Text;
import org.eclipse.swt.widgets.ToolBar;
import org.eclipse.swt.widgets.Tree;
import org.eclipse.swt.widgets.Combo;
import org.eclipse.jface.viewers.ComboViewer;

public class MainWindow {

	protected Shell shell;
	private Text text;

	/**
	 * Launch the application.
	 * @param args
	 */
	public static void main(String[] args) {
		try {
			MainWindow window = new MainWindow();
			window.open();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	/**
	 * Open the window.
	 */
	public void open() {
		Display display = Display.getDefault();
		createContents();
		shell.open();
		shell.layout();
		while (!shell.isDisposed()) {
			if (!display.readAndDispatch()) {
				display.sleep();
			}
		}
	}

	/**
	 * Create contents of the window.
	 */
	protected void createContents() {
		shell = new Shell();
		shell.setSize(450, 300);
		shell.setText("SWT Application");
		
		Button btnNewButton = new Button(shell, SWT.NONE);
		btnNewButton.setGrayed(true);
		btnNewButton.setBounds(104, 31, 75, 25);
		btnNewButton.setText("bite me");
		
		text = new Text(shell, SWT.BORDER);
		text.setBounds(21, 31, 76, 21);
		
		Tree tree = new Tree(shell, SWT.BORDER);
		tree.setBounds(10, 58, 85, 85);
		
		ComboViewer comboViewer = new ComboViewer(shell, SWT.NONE);
		Combo combo = comboViewer.getCombo();
		combo.setBounds(104, 58, 91, 23);

	}
}
