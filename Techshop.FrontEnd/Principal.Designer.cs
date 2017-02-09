namespace Techshop.FrontEnd
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btnImportPedidosSkyhub = new System.Windows.Forms.Button();
            this.btnImportPedidoProtheus = new System.Windows.Forms.Button();
            this.btnApagaPedidosBaseSkyhub = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportPedidosSkyhub
            // 
            this.btnImportPedidosSkyhub.Location = new System.Drawing.Point(12, 37);
            this.btnImportPedidosSkyhub.Name = "btnImportPedidosSkyhub";
            this.btnImportPedidosSkyhub.Size = new System.Drawing.Size(150, 48);
            this.btnImportPedidosSkyhub.TabIndex = 0;
            this.btnImportPedidosSkyhub.Text = "Importar Pedidos Skyhub";
            this.btnImportPedidosSkyhub.UseVisualStyleBackColor = true;
            this.btnImportPedidosSkyhub.Click += new System.EventHandler(this.btnImportPedidosSkyhub_Click);
            // 
            // btnImportPedidoProtheus
            // 
            this.btnImportPedidoProtheus.Location = new System.Drawing.Point(12, 105);
            this.btnImportPedidoProtheus.Name = "btnImportPedidoProtheus";
            this.btnImportPedidoProtheus.Size = new System.Drawing.Size(150, 48);
            this.btnImportPedidoProtheus.TabIndex = 1;
            this.btnImportPedidoProtheus.Text = "Gravar Pedidos Base Espelho Protheus";
            this.btnImportPedidoProtheus.UseVisualStyleBackColor = true;
            this.btnImportPedidoProtheus.Click += new System.EventHandler(this.btnImportPedidoProtheus_Click);
            // 
            // btnApagaPedidosBaseSkyhub
            // 
            this.btnApagaPedidosBaseSkyhub.Location = new System.Drawing.Point(12, 178);
            this.btnApagaPedidosBaseSkyhub.Name = "btnApagaPedidosBaseSkyhub";
            this.btnApagaPedidosBaseSkyhub.Size = new System.Drawing.Size(150, 48);
            this.btnApagaPedidosBaseSkyhub.TabIndex = 2;
            this.btnApagaPedidosBaseSkyhub.Text = "ApagaPedidosBaseEspelhoSkyhub";
            this.btnApagaPedidosBaseSkyhub.UseVisualStyleBackColor = true;
            this.btnApagaPedidosBaseSkyhub.Click += new System.EventHandler(this.btnApagaPedidosBaseSkyhub_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "ApagaPedidosBaseEspelhoProtheus";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Techshop.FrontEnd.Properties.Resources._118752_Papel_de_Parede_Mac_Aurora_Vermelha_2560x1440;
            this.ClientSize = new System.Drawing.Size(701, 398);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnApagaPedidosBaseSkyhub);
            this.Controls.Add(this.btnImportPedidoProtheus);
            this.Controls.Add(this.btnImportPedidosSkyhub);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Front End Projeto Skyhub";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportPedidosSkyhub;
        private System.Windows.Forms.Button btnImportPedidoProtheus;
        private System.Windows.Forms.Button btnApagaPedidosBaseSkyhub;
        private System.Windows.Forms.Button button1;
    }
}

