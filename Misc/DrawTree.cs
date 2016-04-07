Form form1 = null;
TextBox txtInorder = null;
private SortedBinaryTree m_Tree;
void Main()
{
	form1 = new Form();
	m_Tree=new SortedBinaryTree();
	Button btnAdd = new Button();
	btnAdd.Text = "Draw";
	txtInorder = new TextBox();
	txtInorder.Left=150;
	TextBox txtValue = new TextBox();
	txtValue.Left=50;
	btnAdd.Top=200;
	
	form1.Controls.Add(btnAdd);
	form1.Controls.Add(txtInorder);
	form1.Controls.Add(txtValue);
	form1.Paint += form1_Paint;
	btnAdd.Click += (sender, args) =>
	{
		m_Tree.AddValue(Convert.ToInt32(txtValue.Text));
		txtInorder.Text = m_Tree.Inorder();

		txtValue.Clear();
		txtValue.Focus();
		form1.Invalidate();


	};
	form1.Show();
	form1.Activate();
	Application.Run(form1);

}
public void form1_Paint(object sender, PaintEventArgs e)
{
	e.Graphics.Clear(form1.BackColor);
	//e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit;
	//e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias;

	m_Tree.DrawTree(e.Graphics, form1.Font, Brushes.White, Brushes.Blue, Pens.Black, 8, txtInorder.Bottom + 8);

}
public class SortedBinaryTree
{

	public SortedBinaryNode Root;
	// Constructor.
	public SortedBinaryTree(SortedBinaryNode new_root = null)
	{
		Root = new_root;
	}

	// Return the tree's preorder traversal.
	public string Preorder()
	{
		if (Root == null)
			return "";
		return Root.Preorder();
	}

	// Return the tree's postorder traversal.
	public string Postorder()
	{
		if (Root == null)
			return "";
		return Root.Postorder();
	}

	// Return the tree's inorder traversal.
	public string Inorder()
	{
		if (Root == null)
			return "";
		return Root.Inorder();
	}

	// Add a new value.
	public void AddValue(int value)
	{
		if (Root == null)
		{
			Root = new SortedBinaryNode(value);
		}
		else
		{
			Root.AddValue(value);
		}
	}

	// Draw the tree.
	public void DrawTree(Graphics gr, Font fnt, Brush fill_brush, Brush font_brush, Pen the_pen, int xmin, int ymin)
	{
		if (Root == null)
			return;

		// Position all of the nodes.
		Root.PositionNode(ref xmin, ymin);

		// Draw all of the links.
		Root.DrawBranches(gr, the_pen);

		// Draw all of the nodes.
		Root.DrawNode(gr, fnt, fill_brush, font_brush, the_pen);
	}
}

public class SortedBinaryNode
{
	public int Name;
	public SortedBinaryNode LeftChild;

	public SortedBinaryNode RightChild;
	// Constructor.
	public SortedBinaryNode(int new_name, SortedBinaryNode left_child = null, SortedBinaryNode right_child = null)
	{
		Name = new_name;
		LeftChild = left_child;
		RightChild = right_child;
	}

	// Return the node's preorder traversal.
	public string Preorder()
	{
		string result = "";
		result += Name;
		if (LeftChild != null)
			result += " " + LeftChild.Preorder();
		if (RightChild != null)
			result += " " + RightChild.Preorder();
		return result;
	}

	// Return the node's postorder traversal.
	public string Postorder()
	{
		string result = "";
		if (LeftChild != null)
			result += LeftChild.Postorder();
		if (RightChild != null)
			result += " " + RightChild.Postorder();
		result += " " + Name;
		return result.Trim();
	}

	// Return the node's inorder traversal.
	public string Inorder()
	{
		string result = "";
		if (LeftChild != null)
			result += LeftChild.Inorder();
		result += " " + Name;
		if (RightChild != null)
			result += " " + RightChild.Inorder();
		return result.Trim();
	}

	// Add a new node to the sorted subtree.
	public void AddValue(int value)
	{
		// See if we this value belongs to our right or left.
		if (value < Name)
		{
			// Go left.
			if (LeftChild == null)
			{
				LeftChild = new SortedBinaryNode(value);
			}
			else
			{
				LeftChild.AddValue(value);
			}
		}
		else
		{
			// Go right.
			if (RightChild == null)
			{
				RightChild = new SortedBinaryNode(value);
			}
			else
			{
				RightChild.AddValue(value);
			}
		}
	}

	#region "Drawing Routines"

	private const int RADIUS = 20;
	private const int HGAP = 5;

	private const int VGAP = 10;
	private int m_Cx;

	private int m_Cy;
	// Find the position where we should draw the center of this node.
	public void PositionNode(ref int xmin, int ymin)
	{
		m_Cy = ymin + RADIUS / 2;

		// Position our left subtree.
		if (LeftChild != null)
		{
			LeftChild.PositionNode(ref xmin, ymin + RADIUS + VGAP);
		}

		// If we have two children, allow space between them.
		if ((LeftChild != null) && (RightChild != null))
		{
			xmin += HGAP;
		}

		// Position our right subtree.
		if (RightChild != null)
		{
			RightChild.PositionNode(ref xmin, ymin + RADIUS + VGAP);
		}

		// Position ourself.
		if (LeftChild != null)
		{
			if (RightChild != null)
			{
				// Center between our children.
				m_Cx = (LeftChild.m_Cx + RightChild.m_Cx) / 2;
			}
			else
			{
				// No right child. Center over left child.
				m_Cx = LeftChild.m_Cx;
			}
		}
		else if (RightChild != null)
		{
			// No left child. Center over right child.
			m_Cx = RightChild.m_Cx;
		}
		else
		{
			// No children. We're on our own.
			m_Cx = xmin + RADIUS / 2;
			xmin += RADIUS;
		}
	}

	// Draw branches to our children.
	public void DrawBranches(Graphics gr, Pen the_pen)
	{
		if (LeftChild != null)
		{
			gr.DrawLine(the_pen, m_Cx, m_Cy, LeftChild.m_Cx, LeftChild.m_Cy);
			LeftChild.DrawBranches(gr, the_pen);
		}
		if (RightChild != null)
		{
			gr.DrawLine(the_pen, m_Cx, m_Cy, RightChild.m_Cx, RightChild.m_Cy);
			RightChild.DrawBranches(gr, the_pen);
		}
	}

	// Draw the node in its assigned position.
	public void DrawNode(Graphics gr, Font fnt, Brush fill_brush, Brush font_brush, Pen the_pen)
	{
		// Draw an outline.
		Rectangle rect = new Rectangle(m_Cx - RADIUS / 2, m_Cy - RADIUS / 2, RADIUS, RADIUS);
		gr.FillEllipse(fill_brush, rect);
		gr.DrawEllipse(the_pen, rect);

		// Draw our name.
		using (StringFormat sf = new StringFormat())
		{
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			gr.DrawString(Name.ToString(), fnt, font_brush, m_Cx, m_Cy, sf);
		}

		// Draw our children.
		if (LeftChild != null)
			LeftChild.DrawNode(gr, fnt, fill_brush, font_brush, the_pen);
		if (RightChild != null)
			RightChild.DrawNode(gr, fnt, fill_brush, font_brush, the_pen);
	}

	#endregion

}
