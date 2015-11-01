using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using QuickReportLib.Managers;

namespace QuickReportLib.Controls.Plus
{
    /// <summary>
    /// �Զ���TreeView�ؼ�����ԭ��TreeView�ؼ��Ļ��������ӷ�����������⡣
    /// </summary>
    internal partial class TreeViewPlus : TreeView
    {
        public TreeViewPlus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ǰ����ѡ��״̬��Node������CheckBoxsΪtrue������¡���
        /// </summary>
        public List<TreeNode> SelectedNodes
        {
            get
            {
                if (!CheckBoxes)
                {
                    return new List<TreeNode>();
                }
                return GetSelectedNodes();
            }
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                SelectedNode = e.Node;
                CheckTreeNodeSon(e.Node, e.Node.Checked);
                if (e.Node.Parent != null && !e.Node.Checked)
                {
                    CheckTreeNodeParent(e.Node, false);
                }
            }
            base.OnAfterCheck(e);
        }

        private void CheckTreeNodeSon(TreeNode treeNode, bool checkState)
        {
            if (treeNode.Nodes.Count > 0)
            {
                treeNode.Checked = checkState;
                foreach (TreeNode node in treeNode.Nodes)
                {
                    CheckTreeNodeSon(node, checkState);
                }
            }
            else
            {
                treeNode.Checked = checkState;
            }
        }

        private void CheckTreeNodeParent(TreeNode treeNode, bool checkState)
        {
            if (treeNode.Parent != null)
            {
                treeNode.Parent.Checked = checkState;
                CheckTreeNodeParent(treeNode.Parent, checkState);
            }
        }

        private List<TreeNode> GetSelectedNodes()
        {
            List<TreeNode> t = new List<TreeNode>();
            foreach (TreeNode node in Nodes)
            {
                GetSelectedNode(node, t);
            }
            return t;
        }

        private void GetSelectedNode(TreeNode node, List<TreeNode> nodes)
        {
            if (node.Checked)
            {
                nodes.Add(node);
            }
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode n in node.Nodes)
                {
                    if (n.Checked)
                    {
                        GetSelectedNode(n, nodes);
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            #region ���TreeView���ж�ѡ��ʱ�Դ���BUG��
            if (m.Msg == 0x203)//���Ϊ˫����
            {
                if (CheckBoxes && SelectedNode != null)
                {
                    Point p =PointToClient(MousePosition);
                    if (!SelectedNode.Bounds.Contains(p))//�������ĵ㲻����Node�ϡ�
                    {
                        m.Result = IntPtr.Zero;
                        WindowManager.MouseClick();//��˫���䵥����
                        return;
                    }
                }
            }
            #endregion
            base.WndProc(ref m);
        }
    }
}
