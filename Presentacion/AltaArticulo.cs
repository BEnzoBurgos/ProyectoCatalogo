using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;

namespace Presentacion
{
    public partial class AltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;


        public AltaArticulo()
        {
            InitializeComponent();
        }
        public AltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validarTxt()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, Complete el campo codigo.");
                return true;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, Complete el campo codigo.");
                return true;
            }
            return false;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarTxt())
                    return;
                if(articulo == null)
                    articulo  = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.imagenurl = txtUrlImagen.Text;
                // AGREGAR DECIMAL.PARSE !! ERA LO QUE FALTABA!!
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.Categoria = (Categorias)cboCategoria.SelectedItem;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
               
           if(articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente!");
                }
           else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente!");
                    
                }
                Close();




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void AltaArticulo_Load(object sender, EventArgs e)
        {
            CategoriasNegocio categoriaNegocio = new CategoriasNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {   
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)

                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    cargarImagen(articulo.imagenurl);
                    txtUrlImagen.Text = articulo.imagenurl;
                    txtPrecio.Text = articulo.Precio.ToString();

                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbArticulo.Load(imagen);
            }
            catch (Exception)
            {

                pbArticulo.Load("https://endlessicons.com/wp-content/uploads/2012/11/image-holder-icon-614x460.png");
            }
        }
    }
}
